<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageTurfs.aspx.cs" Inherits="TurfManagementSystem.ManageTurfs" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Turfs</title>
    <link href="CSS/Style.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@700&display=swap" rel="stylesheet" />
</head>
<body>
    <nav class="navbar">
        <div class="logo">
            <img src="images/llogo.png" alt="Turf Logo" />
        </div>
        <ul class="nav-links">
            <li><a href="Home.aspx">Home</a></li>
            <li><a href="Turfs.aspx">Turfs</a></li>
            <li><a href="Booking.aspx">Booking</a></li>
            <li><a href="Contact.aspx">Contact Us</a></li>
            <li><a href="Login.aspx">Login</a></li>
        </ul>
    </nav>

    <form id="form1" runat="server">
        <div class="container">
            <h2>Manage Turfs</h2>

            <asp:GridView ID="gvTurfs" runat="server" AutoGenerateColumns="False" CssClass="turfs-table"
                OnRowEditing="gvTurfs_RowEditing"
                OnRowUpdating="gvTurfs_RowUpdating"
                OnRowCancelingEdit="gvTurfs_RowCancelingEdit"
                OnRowDeleting="gvTurfs_RowDeleting"
                DataKeyNames="turf_id">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="location" HeaderText="Location" />
                    <asp:TemplateField HeaderText="Is Active">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkActive" runat="server" Checked='<%# Eval("is_active") %>' Enabled="false" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkActiveEdit" runat="server" Checked='<%# Bind("is_active") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>

            <div class="button-panel">
                <asp:Button ID="btnAdd" runat="server" Text="Add Turf" OnClick="btnAdd_Click" CssClass="btn btn-edit" />
            </div>
        </div>
    </form>
</body>
</html>
