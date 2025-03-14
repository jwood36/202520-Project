<%@ Page Title="Results Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="quiz.ResultsPage" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="cphNavBar" runat="server">
    <link href="/Content/Results.css" rel="stylesheet" type="text/css"/>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainBody" runat="server">  
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="resultsPageTitle">Your Quiz Results</h1>
            
            <!-- Results Box Container -->
            <div class="results-container">
                <!-- Results -->
                <div class="results">
                    <asp:Label ID="ScoreLabel" runat="server" Font-Bold="true" />
                    <br />
                    <asp:Label ID="PercentageLabel" runat="server" />
                </div>

                <!-- Disclaimer -->
                <div class="disclaimer">
                    <h3>Disclaimer</h3>
                    <asp:Label ID="DisclaimerLabel" runat="server" Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                        Disclaimer Text will state how the results of the Test will be transmitted, stored, and used. Currently there are no legal or informative disclaimers constructed." />
                </div>
            </div>
        </section>
    </main>
</asp:Content>

