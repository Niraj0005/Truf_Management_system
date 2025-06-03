using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Truf_Management_system.Data_Layer
{
    public class DatabaseDB
    {
        public void CreateDatabase()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-36NQU3DC\SQLEXPRESS;Integrated Security=True"))
            {
                con.Open();

                string qur = "SELECT COUNT(*) FROM sys.databases WHERE name='Truf_Management'";
                SqlCommand cmd = new SqlCommand(qur, con);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    string dropDb = "ALTER DATABASE Truf_Management SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE Truf_Management;";
                    SqlCommand dropCmd = new SqlCommand(dropDb, con);
                    dropCmd.ExecuteNonQuery();
                }

                SqlCommand createCmd = new SqlCommand("CREATE DATABASE Truf_Management", con);
                createCmd.ExecuteNonQuery();

                con.Close();
            }

            Console.WriteLine("Database created successfully.");
        }
    }
}