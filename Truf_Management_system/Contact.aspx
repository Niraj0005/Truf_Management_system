<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Truf_Management_system.Contact" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Us - Turf Management System</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
    <link rel="stylesheet" href="CSS/Contact.css" />
</head>
<body>
    <form id="form1" runat="server">
       
        <div class="navbar">
            <img src="images/llogo.png" alt="Logo" />
            <div class="nav-links">
                <a href="Default.aspx">Home</a>
                <a href="Turfs.aspx">Turfs</a>
                <a href="Booking.aspx">Booking</a>
                <a href="Contact.aspx">Contact Us</a>
                <a href="LoginPage.aspx">Login</a>
            </div>
        </div>

       
        <div class="container">
            <h2>Contact Us</h2>
            <div class="contact-form">
                <asp:TextBox ID="txtName" runat="server" CssClass="input-field" placeholder="Your Name"></asp:TextBox><br />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="input-field" placeholder="Your Email" TextMode="Email"></asp:TextBox><br />
                <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="4" Columns="40" placeholder="Your Message"></asp:TextBox><br />
                <asp:Button ID="btnSend" runat="server" Text="Send Message" OnClick="btnSend_Click" CssClass="submit-button" /><br /><br />
                <asp:Label ID="lblStatus" runat="server" ForeColor="Green"></asp:Label>
            </div>

            <div class="contact-info">
                <h2>Contact Information</h2>
                <p><i class="fas fa-phone"></i> +1 123 456 789</p>
                <p><i class="fas fa-envelope"></i> niraj@gmail.com</p>
                <p><i class="fas fa-map-marker-alt"></i> 123 Street, Nashik, India</p>
            </div>
        </div>
    </form>
</body>
</html>
