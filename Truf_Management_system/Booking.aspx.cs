using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Truf_Management_system
{
    public partial class Booking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page load logic if needed
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Truf_ManagementConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO bookings_new (user_id, turf_id, slot_id, booking_date, status) " +
                                   "VALUES (@UserID, @TurfID, @SlotID, @BookingDate, @Status)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@UserID", userText.Text.Trim());
                    cmd.Parameters.AddWithValue("@TurfID", turfText.Text.Trim());
                    cmd.Parameters.AddWithValue("@SlotID", slotText.Text.Trim());
                    cmd.Parameters.AddWithValue("@BookingDate", dateText.Text.Trim());
                    cmd.Parameters.AddWithValue("@Status", statusText.SelectedValue);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Optional: Clear fields before redirecting
                        ClearFields();

                        // Redirect to BookingPayment.aspx with query parameters
                        string redirectUrl = $"BookingPayment.aspx?userid={userText.Text.Trim()}&turfid={turfText.Text.Trim()}";
                        Response.Redirect(redirectUrl);
                    }
                    else
                    {
                        lblMessage.Text = "Error: Booking not saved.";
                        lblMessage.CssClass = "error";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.CssClass = "error";
                }
            }
        }

        protected void btnBookingTab_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookingHistory.aspx");
        }

        protected void btnAvailabilityTab_Click(object sender, EventArgs e)
        {
            Response.Redirect("AvailableSlots.aspx");
        }

        private void ClearFields()
        {
            userText.Text = "";
            turfText.Text = "";
            slotText.Text = "";
            dateText.Text = "";
            statusText.SelectedIndex = 0;
        }
    }
}
