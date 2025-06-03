<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Turfs.aspx.cs" Inherits="Truf_Management_system.Turfs" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Turfs Information</title>
    <link href="CSS/turf.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <!-- Navbar -->
        <div class="navbar">
            <div class="logo">
                <a href="Home.aspx">
                    <img src="images/llogo.png" alt="Turf Logo" />
                </a>
            </div>
            <ul class="nav-links">
                <li><a href="Default.aspx">Home</a></li>
                <li><a href="Turfs.aspx">Turfs</a></li>
                <li><a href="Booking.aspx">Bookings</a></li>
                <li><a href="Contact.aspx">Contact</a></li>
            </ul>
        </div>

        <div class="container">
            <h2>Available Turfs</h2>

            <asp:Label ID="lblNoTurfs" runat="server" ForeColor="Red" Visible="false" Text="No turfs found."></asp:Label>

            <!-- Turfs list -->
            <asp:Repeater ID="rptTurfs" runat="server">
                <ItemTemplate>
                    <div class="turf-container">
                        <div class="turf-name"><%# Eval("Name") %></div>
                        <div class="turf-location"><%# Eval("Location") %></div>
                        <div class="button-group">
                            <asp:Button 
                                ID="btnSlots" 
                                runat="server" 
                                Text="Slots" 
                                CommandArgument='<%# Eval("Id") %>' 
                                OnClick="btnSlots_Click" 
                                CssClass="btn btn-blue" />
                            <asp:Button 
                                ID="btnBookings" 
                                runat="server" 
                                Text="Bookings" 
                                CommandArgument='<%# Eval("Id") %>' 
                                OnClick="btnBookings_Click" 
                                CssClass="btn btn-blue" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </form>
</body>
</html>
