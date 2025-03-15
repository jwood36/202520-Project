<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="In_Progress.aspx.cs" Inherits="quiz.In_Progress" %>

<!--
    <link href="/Content/In_Progress.css" type="text/css" rel="stylesheet" />
-->

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainBody" runat="server">
        <div 
            id="timer">
        </div>

        <div id="question-count">Question Count</div>
    <script>

       
    </script>
     
    
    
    <div id="question-number">Question 1</div>

    <div id="question-body">Question Body</div>

    <div id="question-answer-options">Answer Options</div>

    <button OnClick="nextQuestion()"/>Sumbit Answer<button/>

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