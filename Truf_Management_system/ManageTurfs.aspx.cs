using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TurfManagementSystem
{
    public partial class ManageTurfs : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["Truf_ManagementConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTurfs();
            }
        }

        private void LoadTurfs()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT turf_id, name, location, is_active FROM turfs_new";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvTurfs.DataSource = dt;
                gvTurfs.DataBind();
            }
        }

        protected void gvTurfs_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTurfs.EditIndex = e.NewEditIndex;
            LoadTurfs();
        }

        protected void gvTurfs_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTurfs.EditIndex = -1;
            LoadTurfs();
        }

        protected void gvTurfs_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int turfId = Convert.ToInt32(gvTurfs.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvTurfs.Rows[e.RowIndex];

            string name = ((TextBox)row.Cells[0].Controls[0]).Text?.Trim();
            string location = ((TextBox)row.Cells[1].Controls[0]).Text?.Trim();
            CheckBox chkActive = (CheckBox)row.FindControl("chkActiveEdit");
            bool isActive = chkActive != null && chkActive.Checked;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(location))
            {
                Response.Write("Name and location cannot be empty.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE turfs_new SET name = @name, location = @location, is_active = @is_active WHERE turf_id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@is_active", isActive);
                cmd.Parameters.AddWithValue("@id", turfId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Response.Write("Error updating turf: " + ex.Message);
                }
            }

            gvTurfs.EditIndex = -1;
            LoadTurfs();
        }

        protected void gvTurfs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int turfId = Convert.ToInt32(gvTurfs.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM turfs_new WHERE turf_id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", turfId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Response.Write("Error deleting turf: " + ex.Message);
                }
            }

            LoadTurfs();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO turfs_new (name, location, is_active) VALUES (@name, @location, @is_active)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", "New Turf");
                cmd.Parameters.AddWithValue("@location", "New Location");
                cmd.Parameters.AddWithValue("@is_active", true);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Response.Write("Error adding turf: " + ex.Message);
                }
            }

            LoadTurfs();
        }
    }
}
