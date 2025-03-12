<%@ Page Language="C#" MasterPageFile="~/Site.Master" CodeFile="LoginPro.aspx.cs" Inherits="Login.LoginProcessing"%>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="LoginPage.css" />
    <script src="LoginPage.js"></script>
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="cphMainBody" runat="server">
    <asp:Label ID="fnLabel" runat="server" Text="First Name: "/>
    <asp:TextBox ID="fname" runat="server"/>
    <br />
    <asp:Label ID="Email_Label" runat="server" Text="Email: "/>
    <asp:TextBox ID="EmailTB" runat="server"/>
    <br />
    <asp:Label ID="PW_Label" runat="server" Text="Password: "/>
    <asp:TextBox TextMode="Password" ID="PWTB" runat="server"/>
    <br />
    <asp:Button ID="submit" runat="server" Text="Submit" OnClick="Validate"/>
</asp:Content>

