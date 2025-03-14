<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="In_Progress.aspx.cs" Inherits="quiz.In_Progress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainBody" runat="server">
        <div 
            id="timer">
        </div>
    <script>
        var totalAmountOfTime = 7200; //this is total time in seconds so 300 seconds is 5mins

        var min = parseInt(totalAmountOfTime / 60); //this variable will take the totalamountoftime divide by 60 to get the minutes and parse
        var sec = parseInt(totalAmountOfTime % 60);// sec variable gets the remainder of the totalAmountOfTime with the % sign
        var timer;

        //checkTime function takes the totalAmountOfTime in seconds and converts it to minutes and seconds
        function checkTime() {
            document.getElementById("timer").innerHTML = "Time left: " + min + " minutes ";
            //this if statement checks to make sure the timer does not go to the negative
            if (totalAmountOfTime > 0) {
                totalAmountOfTime = totalAmountOfTime - 1;
                min = parseInt(totalAmountOfTime / 60);
                sec = parseInt(totalAmountOfTime % 60);
                
            }

        }
        timer = setInterval(checkTime, 1000);
       
    </script>
     
    
    
    <div id="question-number">Question 1</div>

    <script>
        let currentQuestionIndex = 0; // variable used to track the current question number/index

        // function to update the question and counter
        function updateQuestion() {
            // updates question text
            document.getElementById('question').textContent = questions[currentQuestionIndex];

            // updates question number display (ex: "Question 1")
            document.getElementById('question-number').textContent = `Question ${currentQuestionIndex + 1}`;
        }

        // function to move to next question
        function nextQuestion() {
            currentQuestionIndex++;

            if (currentQuestionIndex < questions.length) {
                // updates questions and counter
                updateQuestion();
            } else {
                // when all questions are done, shows completion message
                document.getElementById('question').textContent = "You have completed the quiz!";
                document.getElementById('question-number').textContent = "";
            }
        }
    </script>

    </asp:Content>
