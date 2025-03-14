<%@ Page Title="Results Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="quiz.ResultsPage" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="cphNavBar" runat="server">
    <link href="/Content/ResultsPage.css" rel="stylesheet" type="text/css"/>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainBody" runat="server">  
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="resultsPageTitle">Your Quiz Results</h1>
            <table align="center">
                <tr>
                    <td>Quiz:</td>
                    <td><asp:Label ID="QuizTitleLabel" runat="server" /></td>
                </tr>
                <tr>
                    <td>Score:</td>
                    <td><asp:Label ID="ScoreLabel" runat="server" /></td>
                </tr>
            </table>
        </section>
    </main>
</asp:Content>
