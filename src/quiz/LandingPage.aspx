<%@ Page Title="Landing Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="quiz.LandingPage" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="cphNavBar" runat="server">
    <link href="/Content/LandingPage.css" rel="stylesheet" type="text/css"/>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainBody" runat="server">  
        <main>
            <section class="row" aria-labelledby="aspnetTitle">
                <h1 id="landingPageTitle">Landing Page</h1>
                <table align="center">
                    <tr>
                        <td>Term:</td>
                    </tr>
                    <tr >
                        <td>User: <input type="text" placeholder="A########"/></td>
                    </tr>
                    <tr >
                        <td>Time: </td>
                    </tr>
                    <tr align="center">
                       <td><input type="submit" value="Start" /></td>
                    </tr>
                </table>
            </section>
        </main>
</asp:Content>