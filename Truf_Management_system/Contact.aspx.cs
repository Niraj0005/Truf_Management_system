using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Truf_Management_system
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string message = txtMessage.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message))
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Please fill all fields.";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["Truf_ManagementConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO ContactMessages (Name, Email, Message) VALUES (@Name, @Email, @Message)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Message", message);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            txtName.Text = "";
            txtEmail.Text = "";
            txtMessage.Text = "";
            lblStatus.ForeColor = System.Drawing.Color.Green;
            lblStatus.Text = "Your message has been sent successfully!";
        }
    }
}
