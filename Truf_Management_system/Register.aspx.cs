using System;
using System.Configuration;
using System.Data.SqlClient;

namespace YourNamespace
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string role = "user";

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please fill in all required fields.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string cs = ConfigurationManager.ConnectionStrings["Truf_ManagementConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    con.Open();

                    string query = @"INSERT INTO users_new (name, email, password, phone, role)
                                     VALUES (@name, @email, @password, @phone, @role);
                                     SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                        cmd.Parameters.AddWithValue("@role", role);

                        object result = cmd.ExecuteScalar();
                    }

                    lblMessage.Text = "Registration successful!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    txtName.Text = txtEmail.Text = txtPassword.Text = txtPhone.Text = "";
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        lblMessage.Text = "This email is already registered.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblMessage.Text = "Database error: " + ex.Message;
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
