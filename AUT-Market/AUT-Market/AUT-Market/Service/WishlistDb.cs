using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Drawing;
using System.IO;
using AUT_Market.Service;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AUT_Market.Service
{
    static class WishlistDb
    {
        public static void AddWish(Book book)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Wishlists (ListingNumber, EmailAddress) " +
                    "VALUES (@ListingNumber, @EmailAddress);", con);
                insertCommand.Parameters.Add("@ListingNumber", SqlDbType.NVarChar).Value = book.ListingNumber;
                insertCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = User.Email;
                insertCommand.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void RemoveWish(Book book)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand insertCommand = new SqlCommand("DELETE FROM Wishlists WHERE ListingNumber = @ListingNumber AND EmailAddress = @EmailAddress;", con);
                insertCommand.Parameters.Add("@ListingNumber", SqlDbType.NVarChar).Value = book.ListingNumber;
                insertCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = User.Email;
                insertCommand.ExecuteNonQuery();
                con.Close();
            }
        }

        public static ObservableCollection<Book> GetWishByUser()
        {
            ObservableCollection<Book> usersBooks = new ObservableCollection<Book>();
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand getCommand = new SqlCommand("SELECT Wishlists.ListingNumber, Books.Title, Books.Author, Books.Price, Books.Edition, Books.CourseCode, Books.Faculty, Books.Condition, Books.Description, Books.Campus, Books.Photo, Books.Posted, Books.IsLike, Books.BooksImgs " +
                    "FROM Books " +
                    "INNER JOIN Wishlists ON Books.ListingNumber = Wishlists.ListingNumber " +
                    "WHERE Wishlists.EmailAddress = @EmailAddress", con);
                getCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = User.Email;
                using (SqlDataReader reader = getCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book book = new Book();

                        book.Title = reader["Title"].ToString();
                        book.Author = reader["Author"].ToString();
                        book.Edition = reader["Edition"].ToString();
                        book.CourseCode = reader["CourseCode"].ToString();
                        book.Faculty = reader["Faculty"].ToString();
                        book.Condition = reader["Condition"].ToString();
                        book.Description = reader["Description"].ToString();
                        book.Price = (int)reader["Price"];
                        book.Campus = reader["Campus"].ToString();
                        book.Posted = (DateTime)reader["Posted"];
                        book.ListingNumber = (Guid)reader["ListingNumber"];
                        book.Islike = (int)reader["Islike"];
                        book.BooksImgs = reader["BooksImgs"].ToString();
                        book.Photo = reader["Photo"].ToString();
                        usersBooks.Add(book);
                    }
                }

                return usersBooks;
            }
        }
    }
}
