﻿using System;
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

namespace AUT_Market
{
    /*
     * Currently not working with images will update later
     * may need exception handling
     */
   static class BooksDb
{
        public static int AddBook(Book newBook )
        {
            int result=0;
            using(SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand insertCommand = new SqlCommand("DECLARE @MyTableVar table (ListingNumber uniqueidentifier)" +
                    "INSERT INTO Books (Title, Author, Edition, CourseCode, Faculty, Price, Condition, Description, EmailAddress, Campus,Photo, Posted,BooksImgs) " +
                    "OUTPUT INSERTED.ListingNumber into @MyTableVar " +
                    "VALUES (@Title, @Author, @Edition, @CourseCode, @Faculty, @Price, @Condition, @Description, @Email, @Campus,@Photo, @Posted,@BooksImgs);" +
                    "SELECT ListingNumber FROM @MyTableVar", con);
                insertCommand.Parameters.Add("@Title", SqlDbType.NVarChar).Value = newBook.Title;
                insertCommand.Parameters.Add("@Author", SqlDbType.NVarChar).Value = newBook.Author;
                insertCommand.Parameters.Add("@Edition", SqlDbType.NVarChar).Value = newBook.Edition;
                insertCommand.Parameters.Add("@CourseCode", SqlDbType.NVarChar).Value = newBook.CourseCode;
                insertCommand.Parameters.Add("@Faculty", SqlDbType.NVarChar).Value = newBook.Faculty;
                insertCommand.Parameters.Add("@Price", SqlDbType.Int).Value = newBook.Price;
                insertCommand.Parameters.Add("@Condition", SqlDbType.NVarChar).Value = newBook.Condition;
                insertCommand.Parameters.Add("@Description", SqlDbType.NVarChar).Value = newBook.Description;
                insertCommand.Parameters.Add("@Email",SqlDbType.NVarChar).Value = User.Email;
                insertCommand.Parameters.Add("@Campus", SqlDbType.NVarChar).Value = newBook.Campus;
                insertCommand.Parameters.Add("@Photo", SqlDbType.NVarChar).Value = newBook.Photo;
                insertCommand.Parameters.Add("@Posted", SqlDbType.DateTime).Value = DateTime.Now;
                insertCommand.Parameters.Add("@BooksImgs", SqlDbType.VarChar).Value = newBook.BooksImgs;
                result = insertCommand.ExecuteNonQuery();
                con.Close();
            }
            return result;
        }

        public static ObservableCollection<Book> GetBooks()
        {
            ObservableCollection<Book> allBooks = new ObservableCollection<Book>();
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand getCommand = new SqlCommand("SELECT * FROM ViewBooksUsers", con);
                using(SqlDataReader reader = getCommand.ExecuteReader())
                {
                    allBooks = ReadtoListBook(reader);
                }
                con.Close();
            }
            return allBooks;
        }
        public static Book GetBooks(string listingnumber)
        {
            Book allBooks = new Book();
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand getCommand = new SqlCommand("SELECT * FROM ViewBooksUsers where listingnumber=@listingnumber", con);
                getCommand.Parameters.Add("@listingnumber", SqlDbType.VarChar).Value = listingnumber;
                using (SqlDataReader reader = getCommand.ExecuteReader())
                {
                    allBooks = ReadtoBook(reader);
                }
                con.Close();
            }
            return allBooks;
        }
        public static ObservableCollection<Book> GetBookByUser(User user)
        {
            ObservableCollection<Book> usersBooks = new ObservableCollection<Book>();
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand getCommand = new SqlCommand("Select * FROM ViewBooksUsers WHERE EmailAddress = @EmailAddress", con);
                getCommand.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = User.Email;
                using (SqlDataReader reader = getCommand.ExecuteReader()){
                    usersBooks = ReadtoListBook(reader);
                }
                return usersBooks;
            }
        }

        public static ObservableCollection<Book> GetBooksByShoper(string EmailAddress)
        {
            ObservableCollection<Book> allBooks = new ObservableCollection<Book>();
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand getCommand = new SqlCommand("SELECT * FROM ViewBooksUsers where ShopEmailAddress=@ShopEmailAddress", con);
                getCommand.Parameters.Add("@ShopEmailAddress", SqlDbType.VarChar).Value = EmailAddress;
                using (SqlDataReader reader = getCommand.ExecuteReader())
                {
                    allBooks = ReadtoListBook(reader);
                }
                con.Close();
            }
            return allBooks;
        }

        public static int getTotalSale(string EmailAddress) {
            int result = 0;
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand getCommand = new SqlCommand("select count(1) as Total from ViewBooksUsers where ShopEmailAddress=@EmailAddress", con);
                getCommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = EmailAddress;
                object obj = getCommand.ExecuteScalar();
                con.Close();
                if (obj == null) result = 0;
                else
                {
                    result = (int)obj;
                }
            }
            return result;
        }

        public static void RemoveBook(Book delBook)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand delCommand = new SqlCommand("DELETE FROM Books WHERE ListingNumber=@ListingNumber", con);
                delCommand.Parameters.AddWithValue("@ListingNumber", SqlDbType.UniqueIdentifier).Value = delBook.ListingNumber;
                delCommand.ExecuteNonQuery();
                con.Close();
            }
        }

       static ObservableCollection<Book> ReadtoListBook(SqlDataReader reader) {
            ObservableCollection<Book> usersBooks = new ObservableCollection<Book>();
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
                book.ShopUserName = reader["ShopUserName"].ToString();
                book.ShopEmailAddress = reader["ShopEmailAddress"].ToString();
                book.BooksImgs = reader["BooksImgs"].ToString();
                book.Photo = reader["Photo"].ToString();
                usersBooks.Add(book);
            }
            return usersBooks;
        }
        static Book ReadtoBook(SqlDataReader reader)
        {
            Book book = new Book();
            while (reader.Read())
            {
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
                book.ShopUserName = reader["ShopUserName"].ToString();
                book.ShopEmailAddress = reader["ShopEmailAddress"].ToString();
                book.BooksImgs = reader["BooksImgs"].ToString();
                book.Photo = reader["Photo"].ToString();
            }
            return book;
        }
    }
}
