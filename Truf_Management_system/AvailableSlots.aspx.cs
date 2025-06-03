using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Truf_Management_system
{
    public partial class AvailableSlots : System.Web.UI.Page
    {
        string connectionString = @"Data Source=LAPTOP-36NQU3DC\SQLEXPRESS;Initial Catalog=Truf_Management;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTurfDropdown();
                BindDateDropdown();
                gvSlots.DataSource = null;
                gvSlots.DataBind();
            }
        }

        private void BindTurfDropdown()
        {
            ddlTurf.Items.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT turf_id, name FROM turfs WHERE is_active = 1";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ddlTurf.Items.Add(new ListItem(reader["name"].ToString(), reader["turf_id"].ToString()));
                    }
                    reader.Close();
                }
            }

            ddlTurf.Items.Insert(0, new ListItem("-- Select Turf --", ""));
        }

        private void BindDateDropdown()
        {
            ddlDate.Items.Clear();
            for (int i = 0; i < 7; i++)
            {
                DateTime date = DateTime.Today.AddDays(i);
                string dateStr = date.ToString("yyyy-MM-dd");
                ddlDate.Items.Add(new ListItem(dateStr, dateStr));
            }
            ddlDate.Items.Insert(0, new ListItem("-- Select Date --", ""));
        }

        protected void ddlTurf_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAvailableSlots();
        }

        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAvailableSlots();
        }

        private void LoadAvailableSlots()
        {
            lblMessage.Text = "";

            if (string.IsNullOrEmpty(ddlTurf.SelectedValue) || string.IsNullOrEmpty(ddlDate.SelectedValue))
            {
                gvSlots.DataSource = null;
                gvSlots.DataBind();
                lblMessage.Text = "Please select both turf and date to view available slots.";
                return;
            }

            int turfId = int.Parse(ddlTurf.SelectedValue);
            string date = ddlDate.SelectedValue;

            var slots = GetAvailableSlotsFromDatabase(date, turfId);

            if (slots.Count > 0)
            {
                gvSlots.DataSource = slots;
                gvSlots.DataBind();
            }
            else
            {
                gvSlots.DataSource = null;
                gvSlots.DataBind();
                lblMessage.Text = "No slots available for the selected turf and date.";
            }
        }

        private List<Slot> GetAvailableSlotsFromDatabase(string date, int turfId)
        {
            List<Slot> slots = new List<Slot>();

            string query = @"
                SELECT s.slot_id, s.turf_id, s.start_time, s.end_time, s.price
                FROM slots s
                WHERE s.turf_id = @turfId
                AND s.slot_id NOT IN (
                    SELECT b.slot_id FROM bookings b WHERE b.booking_date = @date
                )";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@turfId", turfId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    slots.Add(new Slot
                    {
                        slot_id = Convert.ToInt32(reader["slot_id"]),
                        turf_id = Convert.ToInt32(reader["turf_id"]),
                        start_time = ((TimeSpan)reader["start_time"]).ToString(@"hh\:mm"),
                        end_time = ((TimeSpan)reader["end_time"]).ToString(@"hh\:mm"),
                        price = Convert.ToDecimal(reader["price"]),
                        status = "AVAILABLE"
                    });
                }
                reader.Close();
            }

            return slots;
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int slotId = int.Parse(btn.CommandArgument);
            string date = ddlDate.SelectedValue;

            Response.Redirect($"Booking.aspx?date={date}&slotId={slotId}");
        }

        public class Slot
        {
            public int slot_id { get; set; }
            public int turf_id { get; set; }
            public string start_time { get; set; }
            public string end_time { get; set; }
            public decimal price { get; set; }
            public string status { get; set; }
        }
    }
}
