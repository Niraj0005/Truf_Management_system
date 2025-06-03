using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Truf_Management_system
{
    public partial class BookingHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBookingHistory();
            }
        }

        private void BindBookingHistory()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Truf_ManagementConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT history_id, booking_id, action, action_by, action_time FROM booking_history_new", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        GridViewBookingHistory.DataSource = dt;
                        GridViewBookingHistory.DataBind();
                    }
                }
            }
        }
    }
}
