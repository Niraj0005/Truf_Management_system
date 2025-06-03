<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="YourNamespace.AdminDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <link rel="stylesheet" href="CSS/Stylescss.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script type="text/javascript">
        function updateDashboardCounts() {
            $.ajax({
                type: "POST",
                url: "AdminDashboard.aspx/GetDashboardCounts",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var data = response.d;
                    document.getElementById('<%= lblTotalUsers.ClientID %>').innerText = data[0];
                    document.getElementById('<%= lblTotalTurfs.ClientID %>').innerText = data[1];
                    document.getElementById('<%= lblTotalBookings.ClientID %>').innerText = data[2];
                },
                error: function (xhr, status, error) {
                    console.error("Error: " + error);
                }
            });
        }

        $(document).ready(function () {
            updateDashboardCounts();
            setInterval(updateDashboardCounts, 5000); // Refresh every 5 seconds
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <img src="images/llogo.png" alt="Logo" />
            <div class="navbar-links">
                <a href="Home.aspx">Home</a>
                <a href="Turfs.aspx">Turfs</a>
                <a href="Booking.aspx">Bookings</a>
                <a href="Contact.aspx">Contact</a>
                <a href="Logout.aspx">Logout</a>
            </div>
        </div>

        <div class="dashboard-title">Admin Dashboard</div>

        <div class="dashboard-cards">
            <div class="card">
                Total Users<br />
                <asp:Label ID="lblTotalUsers" runat="server" Text="0"></asp:Label>
            </div>
            <div class="card">
                Total Turfs<br />
                <asp:Label ID="lblTotalTurfs" runat="server" Text="0"></asp:Label>
            </div>
            <div class="card">
                Total Bookings<br />
                <asp:Label ID="lblTotalBookings" runat="server" Text="0"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
