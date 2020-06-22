using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Drawing;
using System.IO;
using AUT_Market.Service;

namespace AUT_Market
{
    static class UsersDb
    {
        /*
         * User cant have any null variables
         */
        public static void AddUser(User newUser)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                try
                {
                    con.Open();
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO Users (Name, EmailAddress) " +
                        "VALUES (@Name, @EmailAddress)", con);
                    insertCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = User.Name;
                    insertCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = User.Email;
                    insertCommand.ExecuteNonQuery();
                    con.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("User already added. " + ex.Message);
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------//
        public static User GetUser(string email)
        {
            User user = new User();
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand getCommand = new SqlCommand("SELECT * FROM Users WHERE EmailAddress = @Email", con);
                getCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                using (SqlDataReader reader = getCommand.ExecuteReader())
                {
                    reader.Read();
                    User.Name = reader[1].ToString();
                    User.Email = reader[2].ToString();
                }
                con.Close();
            }
            return user;
        }

        //------------------------------------------------------------------------------------------------------------------------------------//
        public static void DelUser(string email)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand getCommand = new SqlCommand("DELETE FROM Users WHERE EmailAddress = @Email", con);
                getCommand.Parameters.Add("@Email", SqlDbType.Int).Value = email;
                getCommand.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
