using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Truf_Management_system.Data_Layer
{
    public class CreatetableDB
    {
        public void CreateTables()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-36NQU3DC\SQLEXPRESS;Initial Catalog=Truf_Management;Integrated Security=True");
            con.Open();

            string createTables = @"
            CREATE TABLE Payments (
          PaymentId INT IDENTITY(1,1) PRIMARY KEY,
          PaymentMode VARCHAR(50),        
          NameOnCard VARCHAR(100),       
          CardNumber VARCHAR(20),         
          ExpiryDate VARCHAR(7),          
          Amount DECIMAL(10,2),           
          PaymentDate DATETIME DEFAULT GETDATE()
           );

            CREATE TABLE booking_history_new (
            history_id INT IDENTITY(1,1) PRIMARY KEY,
            booking_id INT NOT NULL,
            action VARCHAR(100) NOT NULL,
            action_by VARCHAR(100) NOT NULL,
            action_time DATETIME NOT NULL
            );
            CREATE TABLE users_new ( 
            user_id INT PRIMARY KEY IDENTITY(1,1),
            name NVARCHAR(100) NOT NULL,
            email NVARCHAR(100) NOT NULL,
            password NVARCHAR(100) NOT NULL,
            phone NVARCHAR(15) NOT NULL,
            role NVARCHAR(50) NOT NULL
            );
            CREATE TABLE contact_messages (
            Id INT PRIMARY KEY IDENTITY(1,1),
            Name NVARCHAR(100) NOT NULL,
            Email NVARCHAR(100) NOT NULL,
            Message NVARCHAR(MAX) NOT NULL,
            CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
            );
            CREATE TABLE bookings_new  (
            booking_id INT IDENTITY(1,1) PRIMARY KEY,
            user_id INT NOT NULL,
            turf_id INT NOT NULL,
            slot_id INT NOT NULL,
            booking_date DATE NOT NULL,
            status VARCHAR(50) NOT NULL
            );
                CREATE TABLE turfs_new ( 
                turf_id INT IDENTITY(1,1) PRIMARY KEY,
                name NVARCHAR(100) NOT NULL,
                location NVARCHAR(200) NOT NULL,
                is_active BIT NOT NULL DEFAULT 1
                );
                CREATE TABLE users (
                    user_id INT PRIMARY KEY IDENTITY(1,1)
                    name NVARCHAR(100) NOT NULL,
                    email NVARCHAR(100) NOT NULL,
                    password NVARCHAR(100) NOT NULL,
                    phone NVARCHAR(20),
                    role NVARCHAR(20) CHECK (role IN ('admin', 'manager', 'user')) NOT NULL
                );
                CREATE TABLE turfs (
                    turf_id INT PRIMARY KEY,
                    name NVARCHAR(100) NOT NULL,
                    location NVARCHAR(100) NOT NULL,
                    is_active BIT DEFAULT 1
                );
                CREATE TABLE slots (
                    slot_id INT PRIMARY KEY,
                    turf_id INT,
                    start_time TIME NOT NULL,
                    end_time TIME NOT NULL,
                    price DECIMAL(10,2) NOT NULL,
                    FOREIGN KEY (turf_id) REFERENCES turfs(turf_id)
                );
                CREATE TABLE bookings (
                    booking_id INT PRIMARY KEY,
                    user_id INT,
                    turf_id INT,
                    slot_id INT,
                    booking_date DATE NOT NULL,
                    status NVARCHAR(20) CHECK (status IN ('confirmed', 'pending', 'cancelled')) DEFAULT 'pending',
                    created_at DATETIME DEFAULT GETDATE(),
                    FOREIGN KEY (user_id) REFERENCES users(user_id),
                    FOREIGN KEY (turf_id) REFERENCES turfs(turf_id),
                    FOREIGN KEY (slot_id) REFERENCES slots(slot_id)
                );
                CREATE TABLE booking_history (
                    history_id INT PRIMARY KEY,
                    booking_id INT,
                    action NVARCHAR(50),
                    action_by NVARCHAR(100),
                    action_time DATETIME DEFAULT GETDATE(),
                    FOREIGN KEY (booking_id) REFERENCES bookings(booking_id)
                );
                CREATE TABLE admins (
                    admin_id INT PRIMARY KEY,
                    name NVARCHAR(100) NOT NULL,
                    username NVARCHAR(50) NOT NULL,
                    email NVARCHAR(100) NOT NULL,
                    phone NVARCHAR(15),
                    password NVARCHAR(100) NOT NULL,
                    created_at DATETIME DEFAULT GETDATE()
                );
            ";

            SqlCommand cmd = new SqlCommand(createTables, con);
            cmd.ExecuteNonQuery();

            Console.WriteLine("All tables created successfully in Truf_Management_system database.");
            con.Close();
        }

    }
}