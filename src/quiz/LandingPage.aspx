<%@ Page Title="Landing Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="quiz.LandingPage" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="cphMainBody" runat="server">  
        <main>
            <section class="row" aria-labelledby="aspnetTitle">
                <h1 id="landingPageTitle" style="text-align:center;font-weight:bold;">Landing Page</h1>
                <table align="center" style="width:35rem;border:1px,solid,black;">
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