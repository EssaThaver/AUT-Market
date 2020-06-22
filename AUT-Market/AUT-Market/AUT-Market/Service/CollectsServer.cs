using AUT_Market.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AUT_Market.Service
{
    class CollectsServer
    {
        public static int AddCollect(Collects model)
        {
            int result = -1;
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Collects(EmailAddress,ListingNumber) " +
                    "VALUES (@EmailAddress, @ListingNumber)", con);
                insertCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = model.EmailAddress;
                insertCommand.Parameters.Add("@ListingNumber", SqlDbType.NVarChar).Value = model.ListingNumber;
                result = insertCommand.ExecuteNonQuery();
                con.Close();
            }
            return result;
        }

        //------------------------------------------------------------------------------------------------------------------------------------//
        public static List<Collects> getCollects(string EmailAddress)
        {
            var collects = new List<Collects>();
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand getCommand = new SqlCommand("SELECT * FROM ViewCollects where isdel=0 and UserEmailAddress=@EmailAddress", con);
                getCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = EmailAddress;
                using (SqlDataReader reader = getCommand.ExecuteReader())
                {
                    collects = ReaderToCollects(reader);
                }
                con.Close();
            }
            return collects;
        }

        //------------------------------------------------------------------------------------------------------------------------------------//
        static List<Collects> ReaderToCollects(SqlDataReader reader)
        {
            var collects = new List<Collects>();
            while (reader.Read())
            {
                Collects model = new Collects();

                model.Id = (int)reader["Id"];
                model.EmailAddress = reader["EmailAddress"].ToString();
                model.ListingNumber = reader["ListingNumber"].ToString();
                model.Title = reader["Title"].ToString();
                model.Author = reader["Author"].ToString();
                model.Price = reader["Price"].ToString();
                model.Edition = reader["Edition"].ToString();
                model.CourseCode = reader["CourseCode"].ToString();
                model.Faculty = reader["Faculty"].ToString();
                model.Condition = reader["Condition"].ToString();
                model.Description = reader["Description"].ToString();
                model.Campus = reader["Campus"].ToString();
                model.Photo = reader["Photo"].ToString();
                model.Posted = (DateTime)reader["Posted"];
                model.BooksImgs = reader["BooksImgs"].ToString();
                model.UserEmailAddress = reader["UserEmailAddress"].ToString();
                model.ShopUserName = reader["ShopUserName"].ToString();
                model.ShopEmailAddress = reader["ShopEmailAddress"].ToString();
                collects.Add(model);
            }
            return collects;
        }

        //------------------------------------------------------------------------------------------------------------------------------------//
        public static int getQueryZan(string ListingNumber, string EmailAddress)
        {
            var result = 0;
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand getCommand = new SqlCommand("SELECT Count(*) FROM ViewCollects where  isdel=0 and  UserEmailAddress=@EmailAddress and ListingNumber=@ListingNumber", con);
                getCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = EmailAddress;
                getCommand.Parameters.Add("@ListingNumber", SqlDbType.NVarChar).Value = ListingNumber;
                object obj = getCommand.ExecuteScalar();
                if (obj == null) result = 0;
                else
                {
                    result = (int)obj;
                }
                con.Close();
            }
            return result;
        }

        //------------------------------------------------------------------------------------------------------------------------------------//
        public static int RemoveCollcet(string ListingNumber, string EmailAddress)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand delCommand = new SqlCommand("Delete from Collects where EmailAddress=@EmailAddress and ListingNumber=@ListingNumber", con);
                delCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = EmailAddress;
                delCommand.Parameters.Add("@ListingNumber", SqlDbType.NVarChar).Value = ListingNumber;
                int result = delCommand.ExecuteNonQuery();
                con.Close();
                return result;
            }
        }
    }
}
