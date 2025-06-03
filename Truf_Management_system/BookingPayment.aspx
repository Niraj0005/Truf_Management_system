<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookingPayment.aspx.cs" Inherits="BookingPayment" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Turf Booking Payment</title>
    <link href="CSS/BookingPay.css" rel="stylesheet" type="text/css" />
    <script>
        function showQRCodeScanner() {
            var radios = document.getElementsByName("<%= rblPaymentMode.UniqueID %>");
            var selectedValue = "";
            for (var i = 0; i < radios.length; i++) {
                if (radios[i].checked) {
                    selectedValue = radios[i].value;
                    break;
                }
            }

            if (selectedValue === "UPI") {
                document.getElementById('qrScanner').style.display = 'block';
            } else {
                document.getElementById('qrScanner').style.display = 'none';
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="header">
            <img src="images/llogo.png" alt="Logo" />
            <span>Turf Booking Payment</span>
        </div>

        <div style="margin: 20px;">
            <asp:Button ID="btnBack" runat="server" Text="← Back to Booking Details" CssClass="btn" OnClick="btnBack_Click" />
        </div>

        <div class="container">
            <!-- Booking Summary -->
            <div class="box">
                <h3>Booking Summary</h3>
                <p><strong>Turf Name:</strong> Astro Turf Arena</p>
                <p><strong>Date:</strong> 05 June 2025</p>
                <p><strong>Time Slot:</strong> 5:00 pm - 6:00 pm</p>
                <p><strong>Total Duration:</strong> 1 hour</p>
                <p><strong>Turf Rate:</strong> 800/hr</p>
            </div>

            <!-- Payment Form -->
            <div class="box">
                <h3>Select Payment Mode</h3>

                <asp:RadioButtonList ID="rblPaymentMode" runat="server" CssClass="input" RepeatDirection="Vertical" AutoPostBack="false" onclick="showQRCodeScanner()">
                    <asp:ListItem Text="Credit/Debit Card" Value="Card"></asp:ListItem>
                    <asp:ListItem Text="UPI/Wallet" Value="UPI"></asp:ListItem>
                    <asp:ListItem Text="Net Banking" Value="NetBanking"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="rfvPayment" runat="server"
                    ControlToValidate="rblPaymentMode"
                    InitialValue=""
                    ErrorMessage="* Please select a payment mode"
                    CssClass="validation"
                    Display="Dynamic" />

                <div id="qrScanner">
                    <p><strong>Scan this QR to Pay via UPI:</strong></p>
                    <img src="images/upi.png" alt="UPI QR Code" />
                </div>

                <br />
                <asp:TextBox ID="txtNameOnCard" runat="server" CssClass="input" Placeholder="Name on Card"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server"
                    ControlToValidate="txtNameOnCard"
                    ErrorMessage="* Enter name on card"
                    CssClass="validation"
                    Display="Dynamic" />
                <br />

                <asp:TextBox ID="txtCardNumber" runat="server" CssClass="input" Placeholder="Card Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCard" runat="server"
                    ControlToValidate="txtCardNumber"
                    ErrorMessage="* Enter card number"
                    CssClass="validation"
                    Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revCard" runat="server"
                    ControlToValidate="txtCardNumber"
                    ErrorMessage="* Invalid card number (5 digits)"
                    ValidationExpression="^\d{5}$"
                    CssClass="validation"
                    Display="Dynamic" />
                <br />

                <asp:TextBox ID="txtExpiry" runat="server" CssClass="input" Placeholder="Expiry MM/YY"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvExpiry" runat="server"
                    ControlToValidate="txtExpiry"
                    ErrorMessage="* Enter expiry date"
                    CssClass="validation"
                    Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revExpiry" runat="server"
                    ControlToValidate="txtExpiry"
                    ErrorMessage="* Invalid expiry (MM/YY)"
                    ValidationExpression="^(0[1-9]|1[0-2])\/[0-9]{2}$"
                    CssClass="validation"
                    Display="Dynamic" />
                <br />

                <p><strong>Total Amount:</strong> ₹800</p>

                <asp:Button ID="btnPayNow" runat="server" Text="Confirm & Pay Now" CssClass="btn" OnClick="btnPayNow_Click" />
                <br /><br />
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation" HeaderText="Please correct the following:" ShowSummary="true" />
            </div>
        </div>
    </form>
</body>
</html>
