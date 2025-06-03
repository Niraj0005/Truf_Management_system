<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Truf_Management_system.Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Authentication and Role Management</title>
    <link href="CSS/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>User Authentication<br />and Role Management</h2>
            <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label><br />
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label><br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />

            <asp:Label ID="lblRole" runat="server" Text="Select Role:"></asp:Label><br />
            <asp:RadioButtonList ID="rblRole" runat="server">
                <asp:ListItem>User</asp:ListItem>
                <asp:ListItem>Admin</asp:ListItem>
            </asp:RadioButtonList>

            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /><br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
