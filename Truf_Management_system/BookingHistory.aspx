<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookingHistory.aspx.cs" Inherits="Truf_Management_system.BookingHistory" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Booking History</title>
    <link href="CSS/BookingHistory.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navigation Bar -->
        <div class="navbar">
            <div class="logo">
                <img src="images/llogo.png" alt="Logo" />
            </div>
            <ul class="nav-links">
                <li><a href="Default.aspx">Home</a></li>
                <li><a href="Turfs.aspx">Turfs</a></li>
                <li><a href="Booking.aspx">Booking</a></li>
                <li><a href="Contact.aspx">Contact Us</a></li>
                <li><a href="Login.aspx">Login</a></li>
            </ul>
        </div>

        <!-- Booking History Section -->
        <div class="history-container">
            <h2>Booking History</h2>
            <asp:GridView ID="GridViewBookingHistory" runat="server" AutoGenerateColumns="False" CssClass="grid-table" EmptyDataText="No booking history found.">
                <Columns>
                    <asp:BoundField DataField="history_id" HeaderText="History ID" />
                    <asp:BoundField DataField="booking_id" HeaderText="Booking ID" />
                    <asp:BoundField DataField="action" HeaderText="Action" />
                    <asp:BoundField DataField="action_by" HeaderText="Action By" />
                    <asp:BoundField DataField="action_time" HeaderText="Action Time" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
