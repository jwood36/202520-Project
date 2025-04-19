using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using coding_lms.data;

namespace quiz
{
    public partial class In_Progress : System.Web.UI.Page
    {
        private int currentQuestionIndex; // Track current question
        private int totalQuestions; // Total number of questions (dynamically fetched)
        private Guid currentQuizGuid = Guid.NewGuid(); // Assume you are using a GUID to identify the quiz. Replace as needed.

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initialize the current question index to 0
                currentQuestionIndex = 0;

                // Store current question
                Session["currentQuestionIndex"] = currentQuestionIndex;

                // Fetch total number of questions
                using (TestDB testDb = new TestDB())
                {
                    var questions = testDb.GetQuestion(currentQuizGuid); // Fetch all the questions
                    totalQuestions = questions.Count(); // Set totalQuestions
                }

                // Display the first question
                DisplayQuestion(currentQuestionIndex);
            }
            else
            {
                using (TestDB testDb = new TestDB())
                {
                    var questions = testDb.GetQuestion(currentQuizGuid); // Fetch all the questions
                    totalQuestions = questions.Count(); // Set totalQuestions
                }
                // Retrieve the current question index from session
                currentQuestionIndex = (int)Session["currentQuestionIndex"];
            }
            if (totalQuestions != 0)
            {
                if (totalQuestions == currentQuestionIndex + 2)
                {
                    nextQuestionButton.Text = "Submit Test";
                }
                else
                {
                    nextQuestionButton.Text = "Submit Answer";
                }
            }
        }

        private void DisplayQuestion(int questionIndex)
        {
            // Fetch the question from the database
            using (TestDB testDb = new TestDB())
            {
                var questions = testDb.GetQuestion(currentQuizGuid); // Fetch all the questions for the quiz

                if (questions != null && questions.Count() > questionIndex)
                {
                    // Get the current question from the collection based on the index
                    var question = questions.ElementAt(questionIndex);

                    // Set the question body and render answer options
                    questionBodyLabel.Text = question.Body;
                    questionCountLabel.Text = $"Question {questionIndex + 1} of {totalQuestions}"; // Display question number and total

                    RenderAnswerOptions(question);
                }
            }
        }

        private void RenderAnswerOptions(Question question)
        {
            // Clear previous answer options
            answerOptionsPlaceholder.Controls.Clear();

            if (question.Type == QuestionEnum.TF)
            {
                // Render True/False RadioButtonList for True/False questions
                var radioButtonList = new RadioButtonList();
                radioButtonList.Items.Add(new ListItem("True", "True"));
                radioButtonList.Items.Add(new ListItem("False", "False"));
                answerOptionsPlaceholder.Controls.Add(radioButtonList);
            }
            else if (question.Type == QuestionEnum.MCL || question.Type == QuestionEnum.MCN)
            {
                // Render multiple choice options
                var radioButtonList = new RadioButtonList();

                // Add options based on the answers for the current question
                foreach (var answer in question.Answers)
                {
                    radioButtonList.Items.Add(new ListItem(answer.Text, answer.Key));
                }

                answerOptionsPlaceholder.Controls.Add(radioButtonList);
            }
            else if (question.Type == QuestionEnum.MAL || question.Type == QuestionEnum.MAN)
            {
                // Render multiple answer options as CheckBoxList
                var checkBoxList = new CheckBoxList();

                // Add options based on the answers for the current question
                foreach (var answer in question.Answers)
                {
                    checkBoxList.Items.Add(new ListItem(answer.Text, answer.Key));
                }

                answerOptionsPlaceholder.Controls.Add(checkBoxList);
            }
        }

        // Handle next question button click
        protected void nextQuestion_Click(object sender, EventArgs e)
        {
            // Fetch total number of questions when the button is pressed
            using (TestDB testDb = new TestDB())
            {
                var questions = testDb.GetQuestion(currentQuizGuid);
                if (questions != null)
                {
                    totalQuestions = questions.Count(); // Set totalQuestions
                }
                else
                {
                    totalQuestions = 0; // If no questions exist, set it to 0
                }
            }

            // Get the selected answer
            string selectedAnswer = "";

            if (answerOptionsPlaceholder.Controls.Count > 0)
            {
                // Identify the selected value based on the control type
                if (answerOptionsPlaceholder.Controls[0] is RadioButtonList radioButtonList)
                {
                    selectedAnswer = radioButtonList.SelectedValue; // Get selected answer for radio button
                }
                else if (answerOptionsPlaceholder.Controls[0] is CheckBoxList checkBoxList)
                {
                    // For checkboxes, get the selected answers
                    var selectedItems = checkBoxList.Items.Cast<ListItem>().Where(i => i.Selected).ToList();
                    selectedAnswer = string.Join(",", selectedItems.Select(i => i.Value));
                }
            }

            //Checks if answers are correct
            using (TestDB testDb = new TestDB())
            {
                var questions = testDb.GetQuestion(currentQuizGuid); // Fetch all questions for the quiz
                var question = questions.ElementAt(currentQuestionIndex); // Get current question

                // Find the correct answers for this question
                var correctAnswers = question.Answers.Where(a => a.IsCorrect).Select(a => a.Key).ToList();

                bool isCorrect = correctAnswers.Contains(selectedAnswer); // Check if the selected answer is correct
            }

            // Increment the question index to move to the next question
            currentQuestionIndex++;

            // Update the current question index in session
            Session["currentQuestionIndex"] = currentQuestionIndex;

            // If all questions have been answered, redirect to the results page
            if (currentQuestionIndex >= totalQuestions)
            {
                string termId = Page.RouteData.Values["termid"] as string;
                string crn = Page.RouteData.Values["crn"] as string;
                string shortName = Page.RouteData.Values["shortname"] as string;
                string resultsUrl = $"~/{termId}-{crn}/{shortName}/results";
                Response.Redirect(resultsUrl);
            }
            else
            {
                // Display the next question
                DisplayQuestion(currentQuestionIndex);
            }
        }
    }
}
