using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;

namespace YourNamespace
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDashboardCounts();
            }
        }

        private void LoadDashboardCounts()
        {
            int[] counts = GetDashboardCountsFromDB();
            lblTotalUsers.Text = counts[0].ToString();
            lblTotalTurfs.Text = counts[1].ToString();
            lblTotalBookings.Text = counts[2].ToString();
        }

        [WebMethod]
        public static int[] GetDashboardCounts()
        {
            return GetDashboardCountsFromDB();
        }

        private static int[] GetDashboardCountsFromDB()
        {
            int[] counts = new int[3];
            string cs = ConfigurationManager.ConnectionStrings["Truf_ManagementConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmdUsers = new SqlCommand("SELECT COUNT(*) FROM users_new", con))
                {
                    counts[0] = Convert.ToInt32(cmdUsers.ExecuteScalar());
                }

                using (SqlCommand cmdTurfs = new SqlCommand("SELECT COUNT(*) FROM turfs_new", con))
                {
                    counts[1] = Convert.ToInt32(cmdTurfs.ExecuteScalar());
                }

                using (SqlCommand cmdBookings = new SqlCommand("SELECT COUNT(*) FROM bookings_new", con))
                {
                    counts[2] = Convert.ToInt32(cmdBookings.ExecuteScalar());
                }
            }

            return counts;
        }
    }
}
