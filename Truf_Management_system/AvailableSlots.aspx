<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AvailableSlots.aspx.cs" Inherits="Truf_Management_system.AvailableSlots" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Available Slots</title>
    <link href="CSS/AvailableSlots.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <img src="images/llogo.png" alt="Logo" class="logo" />
            <nav class="nav-bar">
                <a href="Default.aspx">HOME</a>
                <a href="TurfS.aspx">TURF</a>
                <a href="Booking.aspx">BOOKING</a>
                <a href="Contact.aspx">CONTACT US</a>
                <a href="LoginPage.aspx">LOGIN</a>
            </nav>
        </div>

        <h2 class="title">Check Available Slots</h2>

        <div class="selectors">
            <label for="ddlTurf">Select Turf:</label>
            <asp:DropDownList ID="ddlTurf" runat="server" AutoPostBack="true" CssClass="dropdown" OnSelectedIndexChanged="ddlTurf_SelectedIndexChanged" />

            <label for="ddlDate">Select Date:</label>
            <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="true" CssClass="dropdown" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged" />
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="message-label" ForeColor="Red" />

        <asp:GridView ID="gvSlots" runat="server" AutoGenerateColumns="False" CssClass="slot-table" EmptyDataText="No slots available.">
            <Columns>
                <asp:BoundField DataField="start_time" HeaderText="Start Time" DataFormatString="{0:hh\\:mm}" />
                <asp:BoundField DataField="end_time" HeaderText="End Time" DataFormatString="{0:hh\\:mm}" />
                <asp:BoundField DataField="price" HeaderText="Price (₹)" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnBook" runat="server" Text="Book"
                            CommandArgument='<%# Eval("slot_id") %>'
                            OnClick="btnBook_Click"
                            CssClass="btn-book"
                            Enabled='<%# Eval("status").ToString() == "AVAILABLE" %>'
                            OnClientClick="return confirm('Confirm booking this slot?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
