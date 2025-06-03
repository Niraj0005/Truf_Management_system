<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="YourNamespace.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Registration</title>
    <link rel="stylesheet" href="CSS/RegStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-wrapper">
            <div class="form-container">
                <div class="form-header">
                    <img src="images/llogo.png" alt="Logo" class="header-logo" />
                    <h2 class="header-title">User Registration</h2>
                </div>

                <asp:Label ID="lblMessage" runat="server" CssClass="error-message"></asp:Label>

                <div class="form-fields">
                    <asp:TextBox ID="txtName" runat="server" CssClass="input-box" Placeholder="Full Name"></asp:TextBox>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input-box" Placeholder="Email" TextMode="Email"></asp:TextBox>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="input-box" Placeholder="Password" TextMode="Password"></asp:TextBox>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="input-box" Placeholder="Phone Number" TextMode="Phone"></asp:TextBox>
                    <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn-register" OnClick="btnRegister_Click" />
                </div>

                <!-- ✅ Already have account -->
                <div class="login-redirect">
                    <p>Already have an account?
                        <a href="LoginPage.aspx">Login here</a>
                    </p>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
