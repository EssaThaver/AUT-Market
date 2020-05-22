using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Drawing;
using System.IO;

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
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO Users (ID, Name, EmailAddress) " +
                        "VALUES (@ID, @Name, @EmailAddress)", con);
                    insertCommand.Parameters.Add("@ID", SqlDbType.Int).Value = newUser.Id;
                    insertCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = newUser.name;
                    insertCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = newUser.email;
                    insertCommand.ExecuteNonQuery();
                    con.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("User already added. " + ex.Message);
                }
            }
        }

        public static User GetUser(int id)
        {
            User user = new User();
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand getCommand = new SqlCommand("SELECT * FROM Users WHERE ID = @ID", con);
                getCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                using (SqlDataReader reader = getCommand.ExecuteReader())
                {
                    reader.Read();
                    user.Id = id;
                    user.name = reader[1].ToString();
                    user.email = reader[2].ToString();
                }
                con.Close();
            }
            return user;
        }

        public static void DelUser(int id)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand getCommand = new SqlCommand("DELETE FROM Users WHERE ID = @ID", con);
                getCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                getCommand.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}