﻿using System;
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
                    Response.Redirect("~/Error.aspx");
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
                        Response.Redirect("~/Error.aspx");
                        return;
                    }

                    // Display the term and CRN
                    TermLabel.Text = $"{termId}";

                    // Format and display the quiz time
                    TimeLabel.Text = $"{FormatTime(quiz.Time)}";

                    // Assign returned Quiz Total Time to a session variable
                    Session["QuizTime"] = quiz.Time;
            }
            
        }

        protected void StartButton_Click(object sender, EventArgs e)
        {

            // Get student number from input field
            string studentNumber = StudentNumberTextBox.Text.Trim();

            // Validate student number format
            if (string.IsNullOrEmpty(studentNumber) || studentNumber[0] != 'A' || !studentNumber.Substring(1).All(char.IsDigit))
            {
                ErrorLabel.Text = "Invalid student number format. It should start with 'A' followed by 8 digits.";
                return;
            }

            Session["StudentID"] = studentNumber;
            // Get the quiz details from the URL again
            string termId = Page.RouteData.Values["termid"] as string;
            string crn = Page.RouteData.Values["crn"] as string;
            string shortName = Page.RouteData.Values["shortname"] as string;

            // Generate the quiz URL based on the details
            string quizUrl = $"/{termId}-{crn}/{shortName}/in-progress";

            // Display JavaScript confirmation alert with the redirection URL
            string script = $"if (confirm('Are you sure you want to start the quiz? Once started, you cannot go back.')) {{ window.location = '{quizUrl}'; }}";
            ClientScript.RegisterStartupScript(this.GetType(), "Confirmation", script, true);

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