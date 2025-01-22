<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="quiz._Default" %>

<asp:Content ID="cNavBar" ContentPlaceHolderID="cphNavBar" runat="server">
    
</asp:Content>

<asp:Content ID="cMainBody" ContentPlaceHolderID="cphMainBody" runat="server">
    <section id="secUnauthorized">
        <main>
            <section class="row" aria-labelledby="aspnetTitle">
                <h1 id="aspnetTitle" style="text-align:center;">Coding-LMS Quiz App</h1>
                <p class="lead">If you have reached this page, you do not have a valid Quiz URL.  Please contact your Administrator or Instructor/Teacher for assistance.</p>
            </section>
        </main>
    </section>
</asp:Content>
