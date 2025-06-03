<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="Truf_Management_system.AdminLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
     <link href="CSS/AdminLogin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="header">
                <img src="images/llogo.png" alt="Logo" />
                <h2>Admin Login</h2>
            </div>
            <div class="login-container">
                <asp:Label ID="lblError" runat="server" CssClass="error" />
                <asp:TextBox ID="txtUsername" runat="server" Placeholder="Username" />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password" />
                <br /><br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
