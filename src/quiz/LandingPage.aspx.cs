using System;
using coding_lms.data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace quiz
{
    public partial class LandingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                // Get the quiz details from the URL
                string termIdStr = Page.RouteData.Values["termid"] as string;
                string crn = Page.RouteData.Values["crn"] as string;
                string shortName = Page.RouteData.Values["shortname"] as string;

                // If any of these values are missing, send the user back to the homepage
                if (string.IsNullOrEmpty(termIdStr) || string.IsNullOrEmpty(crn) || string.IsNullOrEmpty(shortName))
                {
                    Response.Redirect("~/Default.aspx");
                    return;
                }

                // Convert the term ID to an integer
                int termId = Convert.ToInt32(termIdStr);

                // Look up the quiz in the database
                using (TestDB testDb = new TestDB())
                {
                    Quiz quiz = testDb.GetTest(termId, crn, shortName);

                    // If the quiz doesn't exist, send the user back
                    if (quiz == null)
                    {
                        Response.Redirect("~/Default.aspx");
                        return;
                    }

                    // Display the term and CRN
                    TermLabel.Text = $"{termId}";

                    // Format and display the quiz time
                    TimeLabel.Text = $"{FormatTime(quiz.Time)}";
                }
            
        }

        protected void StartButton_Click(object sender, EventArgs e)
        {
            // Show the confirmation panel
            ConfirmationPanel.Visible = true;
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            // Get the same quiz details again to direct to URL
            string termId = Page.RouteData.Values["termid"] as string;
            string crn = Page.RouteData.Values["crn"] as string;
            string shortName = Page.RouteData.Values["shortname"] as string;

            // Get student number from input field
            string studentNumber = StudentNumberTextBox.Text.Trim();

            // Validate student number format
            if (string.IsNullOrEmpty(studentNumber) || studentNumber[0] != 'A' || !studentNumber.Substring(1).All(char.IsDigit))
            {
                ErrorLabel.Text = "Invalid student number format. It should start with 'A' followed by 8 digits.";
                return;
            }

            // Check if the student exists in TestDB
            //This does not seem functional commenting out for now 
           // using (TestDB testDb = new TestDB())
           // {
           //     Attempt attempt = testDb.GetAttempt(shortName, studentNumber);
           //     if (attempt == null)
           //     {
           //         ErrorLabel.Text = "You are not enrolled in this quiz.";
           //         return;
           //     }
           // }

            // Store student number in session
            Session["StudentID"] = studentNumber;

            string quizUrl = $"~/{termId}-{crn}/{shortName}/in-progress";
            Response.Redirect(quizUrl);
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Hide the confirmation panel if the user cancels
            ConfirmationPanel.Visible = false;
        }


        // Converts time in minutes assumes time is given in minutes and not seconds
        private string FormatTime(int timeInMinutes)
        {
            if (timeInMinutes >= 60)
            {
                int hours = timeInMinutes / 60;
                int minutes = timeInMinutes % 60;
                return (minutes > 0) ? $"{hours} hrs {minutes} mins" : $"{hours} hrs";
            }
            return $"{timeInMinutes} mins"; // If it's less than an hour, just show minutes
        }
    }
}