<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="In_Progress.aspx.cs" Inherits="quiz.In_Progress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="timer">
       
        </div>
        
    </form>
</body>
    <script>
        var TotalAmountOfTime = 300; //this is the total time in seconds 
        var min = parseInt(TotalAmountOfTime / 60); // min variable divives total time by 60
        var sec = parseInt(TotalAmountOfTime % 60); // sec  variable uses modulo to get the remainder of what was divided
        var timeDone;

        //the checkTime function gets the element id and returns the value to that said ID
        function checkTime() {
            document.getElementById("timer").innerHTML = "time left: " + min + " minutes " + ": " + sec + " seconds";//returns the min and sec variable to the html id
            //the if statement checks to make sure it does not go under 0
            if (TotalAmountOfTime > 0) {
                TotalAmountOfTime = TotalAmountOfTime - 1;
                min = parseInt(TotalAmountOfTime / 60);
                sec = parseInt(TotalAmountOfTime % 60);
            }
        }
        timeDone = setInterval(checkTime, 1000);// i use the javascript setInterval function to run checkTime every one sec. 1000 millieseconds = 1 second
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

</html>
