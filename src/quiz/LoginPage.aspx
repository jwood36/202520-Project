<%@ Page Language="C#" CodeFile="LoginPro.aspx.cs" Inherits="Playground2.LoginProcessing2"%>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Login Page</title> 
    <link rel="stylesheet" href="LoginPage.css" />
    <script src="LoginPage.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="fnLabel" runat="server" Text="First Name: "/>
        <asp:TextBox ID="fname" runat="server"/>
        <br />
        <asp:Label ID="Email_Label" runat="server" Text="Email: "/>
        <asp:TextBox ID="EmailTB" runat="server"/>
        <br />
        <asp:Label ID="PW_Label" runat="server" Text="Password: "/>
        <asp:TextBox TextMode="Password" ID="PWTB" runat="server"/>
        <br />
        <asp:Button ID="submit" runat="server" Text="Sumbit" OnClick="Validate"/>
    </form>
</body>
</html>
