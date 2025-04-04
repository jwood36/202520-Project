using System;
using coding_lms.data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

namespace quiz
{
    public partial class ResultsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the Attempt ID
            // Replace Session for testing purposes
            var attemptId = 0123415789;

            if (attemptId == null)
            {
                // Redirect if the attempt ID is not found
                Response.Redirect("~/Default.aspx");
                return;
            }

            // Retrieve the attempt using the ID
            using (TestDB testDb = new TestDB())
            {
                // Retrieve the attempt
                Attempt attempt = testDb.GetAttempt((long)attemptId);

                // Retrieve the quiz
                Quiz quiz = attempt.Quiz;

                // Calculate the number of correct answers
                int correctAnswers = attempt.Results.Count(r => r.IsCorrect);
                int totalQuestions = attempt.Results.Count();

                // Display the results on the page
                ScoreLabel.Text = $"{correctAnswers} / {totalQuestions} ({((double)correctAnswers / totalQuestions) * 100:0.0}%)";
            }
        }
    }
}
