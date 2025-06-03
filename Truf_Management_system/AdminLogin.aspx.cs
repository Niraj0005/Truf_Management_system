using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Truf_Management_system
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string connStr = ConfigurationManager.ConnectionStrings["Truf_ManagementConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "SELECT COUNT(*) FROM admins WHERE username = @username AND password = @password";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                con.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count == 1)
                {
                    Session["admin_username"] = username;
                    Response.Redirect("AdminDashboard.aspx");
                }
                else
                {
                    lblError.Text = "Invalid username or password.";
                }
            }
        }
    }
}
