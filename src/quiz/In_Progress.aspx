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
        /*var TotalAmountOfTime = 300; //this is the total time in seconds 
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
        timeDone = setInterval(checkTime, 1000);// i use the javascript setInterval function to run checkTime every one sec. 1000 millieseconds = 1 second*/
        //this function should do hours and minutes
        function beginTimer(duration, display) {
            var start = Date.now(),//the varibals for the whole function. and use the Date.now object
                diff,
                hours,
                min,
                sec;
            
            // this function gets the difference between the said time
            function timer() {
                // get the number of seconds that have elapsed since beginTimer() was called
                diff = duration - (((Date.now() - start) / 1000) | 0);

                min = (diff / 60) | 0; //i divide with the difference 
                sec = (diff % 60) | 0; // get the remainder of the said time
                //checks the min 
                if (min >= 60) {
                    hours = (min / 60) | 0;
                    min = (min % 60) | 0;
                } else {
                    hours = 0;
                }
                //here i used a ternary operator to add a 0 when it reaches under 10
                hours = hours < 10 ? "0" + hours : hours; //adds the 0 to numbers under 10
                min = min < 10 ? "0" + min : min;
                sec = sec < 10 ? "0" + sec : sec;

                display.textContent = hours + ":" + min + ":" + sec;

                if (diff <= 0) {
                    // starts at the full duration (17:00:00) to make it a little clear
                    start = Date.now() + 1000;
                }
            }
            // i call the function timer and then use setInterval to go through it every one second
            timer();
            setInterval(timer, 1000);
            
        }
        var totalTimeInHours = 3600 * 17.08 // 3600 is how many seconds in an hour and i multiply it by 17. can also do like 17.1 to get more accurate
        display = document.getElementById("timer"); // i give the variable the getElementbyId to show it
        beginTimer(totalTimeInHours, display); //the function gets called
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
