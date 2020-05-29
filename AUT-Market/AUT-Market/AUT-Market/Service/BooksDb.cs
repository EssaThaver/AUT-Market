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

namespace AUT_Market
{
    /*
     * Currently not working with images will update later
     * may need exception handling
     */
   static class BooksDb
{
        public static Guid AddBook(Book newBook /*, User user*/)
        {
            Guid ListingNumber;
            using(SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand insertCommand = new SqlCommand("DECLARE @MyTableVar table (ListingNumber uniqueidentifier)" +
                    "INSERT INTO Books (Title, Author, Edition, CourseCode, Faculty, Price, Condition, Description, EmailAddress, Campus, Posted,IsLike,BooksImgs) " +
                    "OUTPUT INSERTED.ListingNumber into @MyTableVar " +
                    "VALUES (@Title, @Author, @Edition, @CourseCode, @Faculty, @Price, @Condition, @Description, @Email, @Campus, @Posted,@IsLike,@BooksImgs);" +
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
                insertCommand.Parameters.Add("@Posted",SqlDbType.DateTime).Value = DateTime.Now;
                insertCommand.Parameters.Add("@IsLike", SqlDbType.Int).Value = newBook.Islike;
                insertCommand.Parameters.Add("@BooksImgs", SqlDbType.VarChar).Value = newBook.BooksImgs;
                using(SqlDataReader reader = insertCommand.ExecuteReader())
                {
                    reader.Read();
                    ListingNumber = reader.GetGuid(0);
                }
                con.Close();
            }
            return ListingNumber;
        }

        public static List<Book> GetBooks()
        {
            List<Book> allBooks = new List<Book>();
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand getCommand = new SqlCommand("SELECT * FROM Books", con);
                using(SqlDataReader reader = getCommand.ExecuteReader())
                {
                    while(reader.Read())
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
                        allBooks.Add(book);
                    }
                }
                con.Close();
            }
            return allBooks;
        }
        public static List<Book> GetBooks(int Islike)
        {
            List<Book> allBooks = new List<Book>();
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand getCommand = new SqlCommand("SELECT * FROM Books where Islike="+ Islike, con);
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
                        book.Islike= (int)reader["Islike"];
                        book.BooksImgs= reader["BooksImgs"].ToString();
                        book.Photo= reader["Photo"].ToString();
                        allBooks.Add(book);
                    }
                }
                con.Close();
            }
            return allBooks;
        }
        public static ObservableCollection<Book> GetBookss()
        {
            ObservableCollection<Book> allBooks = new ObservableCollection<Book>();
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand getCommand = new SqlCommand("SELECT * FROM Books", con);
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
                        allBooks.Add(book);
                    }
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
                SqlCommand getCommand = new SqlCommand("Select * FROM Books WHERE EmailAddress = @EmailAddress", con);
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
        /*
         * Book must have already been added to the database and have a ListingNumber
         */
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
        public static int UpdateBook(Book book)
        {
            Debug.WriteLine(JsonConvert.SerializeObject(book));
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand delCommand = new SqlCommand("UPDATE Books SET Islike=@Islike where ListingNumber=@ListingNumber", con);
                delCommand.Parameters.AddWithValue("@Islike", SqlDbType.Int).Value = book.Islike;
                delCommand.Parameters.AddWithValue("@ListingNumber", SqlDbType.UniqueIdentifier).Value = book.ListingNumber;
                delCommand.ExecuteNonQuery();
                int result = delCommand.ExecuteNonQuery();
                con.Close();
                return result;
            }
        }

        public static void UpdateBookDetail(Book UpBook)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand UpdateCommand = new SqlCommand("UPDATE Books SET Title = @Title, Author = @Author, Edition = @Edition, CourseCode = @CourseCode, Faculty = @Faculty, Price = @Price, Condition = @Condition, Description = @Description, Campus = @Campus, BooksImgs = @BooksImgs where ListingNumber=@ListingNumber", con);
                UpdateCommand.Parameters.AddWithValue("@ListingNumber", SqlDbType.UniqueIdentifier).Value = UpBook.ListingNumber;
                UpdateCommand.Parameters.Add("@Title", SqlDbType.NVarChar).Value = UpBook.Title;
                UpdateCommand.Parameters.Add("@Author", SqlDbType.NVarChar).Value = UpBook.Author;
                UpdateCommand.Parameters.Add("@Edition", SqlDbType.NVarChar).Value = UpBook.Edition;
                UpdateCommand.Parameters.Add("@CourseCode", SqlDbType.NVarChar).Value = UpBook.CourseCode;
                UpdateCommand.Parameters.Add("@Faculty", SqlDbType.NVarChar).Value = UpBook.Faculty;
                UpdateCommand.Parameters.Add("@Price", SqlDbType.Int).Value = UpBook.Price;
                UpdateCommand.Parameters.Add("@Condition", SqlDbType.NVarChar).Value = UpBook.Condition;
                UpdateCommand.Parameters.Add("@Description", SqlDbType.NVarChar).Value = UpBook.Description;
                UpdateCommand.Parameters.Add("@Campus", SqlDbType.NVarChar).Value = UpBook.Campus;
                UpdateCommand.Parameters.Add("@BooksImgs", SqlDbType.VarChar).Value = UpBook.BooksImgs;
                UpdateCommand.ExecuteNonQuery();
                con.Close();
            }
        }

        public static void PriceChange( Book UpBook)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand delCommand = new SqlCommand("UPDATE Books SET Price=@price where ListingNumber=@ListingNumber", con);
                delCommand.Parameters.AddWithValue("@ListingNumber", SqlDbType.UniqueIdentifier).Value = UpBook.ListingNumber;
                delCommand.Parameters.AddWithValue("@price", SqlDbType.Int).Value = UpBook.Price;
                delCommand.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
