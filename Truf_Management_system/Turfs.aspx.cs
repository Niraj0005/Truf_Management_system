using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Truf_Management_system
{
    public partial class Turfs : System.Web.UI.Page
    {
        public class Turf
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Location { get; set; }
        }

        private string connString = @"Data Source=LAPTOP-36NQU3DC\SQLEXPRESS;Initial Catalog=Truf_Management;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTurfs();
            }
        }

        private void LoadTurfs()
        {
            List<Turf> turfs = GetTurfsFromDatabase();

            if (turfs.Count == 0)
            {
                lblNoTurfs.Visible = true;
                rptTurfs.Visible = false;
            }
            else
            {
                lblNoTurfs.Visible = false;
                rptTurfs.Visible = true;

                rptTurfs.DataSource = turfs;
                rptTurfs.DataBind();
            }
        }

        private List<Turf> GetTurfsFromDatabase()
        {
            var turfs = new List<Turf>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "SELECT turf_id, name, location FROM turfs WHERE is_active = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                turfs.Add(new Turf
                                {
                                    Id = Convert.ToInt32(reader["turf_id"]),
                                    Name = reader["name"].ToString(),
                                    Location = reader["location"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Ideally log exception here
                lblNoTurfs.Text = "Error loading turfs.";
                lblNoTurfs.Visible = true;
            }

            return turfs;
        }

        protected void btnSlots_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.Button)sender;
            int turfId = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect($"AvailableSlots.aspx?turfId={turfId}");
        }

        protected void btnBookings_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.Button)sender;
            int turfId = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect($"Bookings.aspx?turfId={turfId}");
        }
    }
}
