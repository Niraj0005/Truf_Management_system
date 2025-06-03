using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class BookingPayment : Page
{
    string connectionString = "Data Source=LAPTOP-36NQU3DC\\SQLEXPRESS;Initial Catalog=Truf_Management;Integrated Security=True"; // Update this

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblMessage.Text = "";
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Booking.aspx");
    }

    protected void btnPayNow_Click(object sender, EventArgs e)
    {
        string paymentMode = rblPaymentMode.SelectedValue;
        string nameOnCard = txtNameOnCard.Text.Trim();
        string cardNumber = txtCardNumber.Text.Trim();
        string expiry = txtExpiry.Text.Trim();
        decimal amount = 800.00m;

        if (paymentMode == "Card")
        {
            if (string.IsNullOrEmpty(nameOnCard) || string.IsNullOrEmpty(cardNumber) || string.IsNullOrEmpty(expiry))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please fill all card details.";
                return;
            }

            SavePaymentToDatabase(paymentMode, nameOnCard, cardNumber, expiry, amount);
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Card Payment Successful! Thank you for booking.";
        }
        else if (paymentMode == "UPI")
        {
            SavePaymentToDatabase(paymentMode, "", "", "", amount);
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "UPI Payment Initiated. Please scan the QR and complete the transaction.";
        }
        else if (paymentMode == "NetBanking")
        {
            SavePaymentToDatabase(paymentMode, "", "", "", amount);
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Net Banking Payment Successful! Thank you for booking.";
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Please select a payment mode.";
        }
    }

    private void SavePaymentToDatabase(string mode, string name, string card, string expiry, decimal amount)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Payments (PaymentMode, NameOnCard, CardNumber, ExpiryDate, Amount) " +
                           "VALUES (@PaymentMode, @NameOnCard, @CardNumber, @ExpiryDate, @Amount)";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@PaymentMode", mode);
                cmd.Parameters.AddWithValue("@NameOnCard", (object)name ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CardNumber", (object)card ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ExpiryDate", (object)expiry ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Amount", amount);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
