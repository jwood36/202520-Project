<%@ Page Title="Landing Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="quiz.LandingPage" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="cphNavBar" runat="server">
    <link href="/Content/LandingPage.css" rel="stylesheet" type="text/css"/>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainBody" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="landingPageTitle">Landing Page</h1>
            <table align="center">
                <tr>
                    <td>Term: <asp:Label ID="TermLabel" runat="server" /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td>UserID: <asp:TextBox ID="StudentNumberTextBox" runat="server" placeholder="A########" required="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Time: <asp:Label ID="TimeLabel" runat="server" /></td>
                </tr>
                <tr align="center">
                    <!-- "noindent" class is designed to prevent the indent that will be added to other table elements -->
                    <td class="noindent">
                        <asp:Button ID="StartButton" runat="server" CssClass="start-button" Text="Start" OnClick="StartButton_Click" />
                    </td>
                </tr>
                <!-- Hidden confirmation panel -->
                <tr>
                    <td align="center" class="noindent">
                        <asp:Panel ID="ConfirmationPanel" runat="server" Visible="false">
                            <p>Are you sure you want to start the quiz? Once started, you cannot go back.</p>
                            <asp:Button ID="ConfirmButton" runat="server" Text="Yes, Start Quiz" OnClick="ConfirmButton_Click" />
                            <asp:Button ID="CancelButton" runat="server" Text="No, Cancel" OnClick="CancelButton_Click" />
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </section>
    </main>
</asp:Content>