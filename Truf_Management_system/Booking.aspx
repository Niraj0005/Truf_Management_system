<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Booking.aspx.cs" Inherits="Truf_Management_system.Booking" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Booking System</title>
    <link href="CSS/Booking.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <!-- Navbar -->
        <div class="navbar">
            <div class="logo">
                <img src="images/llogo.png" alt="Logo" />
            </div>
            <div class="nav-items">
                <a href="Default.aspx" class="nav-item">Home</a>
                <a href="Turfs.aspx" class="nav-item">Turfs</a>
                <a href="Booking.aspx" class="nav-item">Booking</a>
                <a href="Contact.aspx" class="nav-item">Contact Us</a>
                <a href="LoginPage.aspx" class="nav-item">Login</a>
            </div>
        </div>

        <!-- Title -->
        <div class="title">Booking System</div>

        <!-- Tab Bar -->
        <div class="tab-bar">
            <asp:Button ID="btnBookingTab" runat="server" Text="Booking" CssClass="tab-button" OnClick="btnBookingTab_Click" />
            <asp:Button ID="btnAvailabilityTab" runat="server" Text="Availability" CssClass="tab-button" OnClick="btnAvailabilityTab_Click" />
        </div>

        <!-- Booking Form -->
        <div class="container">
            <div class="booking-form">
                <h3>New Booking</h3>

                <label for="userText">User ID:</label>
                <asp:TextBox ID="userText" runat="server" TextMode="Number" />

                <label for="turfText">Turf ID:</label>
                <asp:TextBox ID="turfText" runat="server" TextMode="Number" />

                <label for="slotText">Slot ID:</label>
                <asp:TextBox ID="slotText" runat="server" TextMode="Number" />

                <label for="dateText">Booking Date:</label>
                <asp:TextBox ID="dateText" runat="server" TextMode="Date" />

                <label for="statusText">Status:</label>
                <asp:DropDownList ID="statusText" runat="server">
                    <asp:ListItem Text="Pending" Value="Pending" />
                    <asp:ListItem Text="Confirmed" Value="Confirmed" />
                    <asp:ListItem Text="Cancelled" Value="Cancelled" />
                </asp:DropDownList>

                <div class="buttons">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="save" OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="cancel" CausesValidation="false" OnClientClick="return confirm('Cancel and clear all fields?');" />
                </div>

                <asp:Label ID="lblMessage" runat="server" EnableViewState="false" />
            </div>
        </div>
    </form>
</body>
</html>
