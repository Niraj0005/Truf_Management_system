using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Truf_Management_system
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Not needed for now
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = rblRole.SelectedValue;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                lblMessage.Text = "All fields are required.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return; // Stop execution if validation fails
            }

            // Use the connection string pointing to Truf_Management database
            string connStr = ConfigurationManager.ConnectionStrings["Truf_ManagementConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT COUNT(*) FROM users_new WHERE email=@Email AND Password=@Password AND Role=@Role";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);

                try
                {
                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        lblMessage.Text = "Login successful!";
                        lblMessage.ForeColor = System.Drawing.Color.Green;

                        // Redirect based on role
                        if (role == "Admin")
                        {
                            Response.Redirect("AdminDashboard.aspx");
                        }
                        else // User role
                        {
                            Response.Redirect("Default.aspx");
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Invalid username, password, or role.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}
