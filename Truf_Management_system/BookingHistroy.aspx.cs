using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Truf_Management_system  
{
    public partial class BookingHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBookingHistory();
            }
        }

        private void LoadBookingHistory()
        {
            var connSetting = ConfigurationManager.ConnectionStrings["Truf_ManagementConnectionString"];
            if (connSetting == null)
            {
                throw new Exception("Connection string 'Truf_ManagementConnectionString' not found.");
            }

            string connStr = connSetting.ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
                    SELECT history_id, booking_id, action, action_by, action_time 
                    FROM booking_history
                    ORDER BY action_time DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    GridViewBookingHistory.DataSource = dt;
                    GridViewBookingHistory.DataBind();
                }
            }
        }
    }
}
