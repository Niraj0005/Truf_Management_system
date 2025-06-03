<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookingHistory.aspx.cs" Inherits="BookingHistory" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Booking History</title>
    <style>
        body {
            margin: 0;
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
        }

        .navbar {
            display: flex;
            justify-content: space-between;
            align-items: center;
            background-color: #00b3e6;
            padding: 10px 20px;
            color: white;
        }

        .logo {
            font-size: 30px;
            font-weight: bold;
        }

        .nav-links {
            list-style: none;
            display: flex;
            gap: 30px;
            margin: 0;
            padding: 0;
        }

        .nav-links li a {
            color: white;
            text-decoration: none;
            font-weight: bold;
        }

        .history-container {
            background-color: white;
            padding: 20px;
            margin: 20px;
            border-radius: 10px;
            text-align: center;
        }

        .history-container h2 {
            background-color: #00b3e6;
            color: white;
            padding: 10px;
            margin-top: 0;
            border-radius: 5px;
        }

        .grid-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .grid-table th,
        .grid-table td {
            border: 1px solid #ccc;
            padding: 12px;
            text-align: center;
        }

        .grid-table th {
            background-color: #f0f0f0;
        }

        @media (max-width: 768px) {
            .navbar {
                flex-direction: column;
                align-items: flex-start;
            }

            .nav-links {
                flex-direction: column;
                width: 100%;
                gap: 10px;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navigation Bar -->
        <div class="navbar">
            <div class="logo">🌱</div>
            <ul class="nav-links">
                <li><a href="Home.aspx">Home</a></li>
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