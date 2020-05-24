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

namespace AUT_Market
{
    /*
     * Currently not working with images will update later
     * may need exception handling
     */
   static class BooksDb
{
        /*
         * Method currently requires that none of the variables in book are null.
         * User must be added to database first
         * Automatically adds a unique listing number to database record which needs to be added to the book instance.
         * 
         * example
         * newbook.ListingNumber = BooksDb.AddBook(newBook);
         */
        public static Guid AddBook(Book newBook /*, User user*/)
        {
            Guid ListingNumber;
            using(SqlConnection con = new SqlConnection(@"Data Source=aut-market.database.windows.net; Initial Catalog=marketdb;User ID=michael.denby;Password=sdpAUT2020"))
            {
                con.Open();
                SqlCommand insertCommand = new SqlCommand("DECLARE @MyTableVar table (ListingNumber uniqueidentifier)" +
                    "INSERT INTO Books (Title, Author, Edition, CourseCode, Faculty, Price, Condition, Description, EmailAddress, Campus, Posted) " +
                    "OUTPUT INSERTED.ListingNumber into @MyTableVar " +
                    "VALUES (@Title, @Author, @Edition, @CourseCode, @Faculty, @Price, @Condition, @Description, @Email, @Campus, @Posted);" +
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

                //byte[] image;
                //using (var ms = new MemoryStream())
                //{
                //    newBook.Photo.Save(ms, newBook.Photo.RawFormat);
                //    image = ms.ToArray();
                //}
                
                //insertCommand.Parameters.Add("@Photo", SqlDbType.Image).Value = image;

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

                        //MemoryStream ms = new MemoryStream(reader.GetSqlBytes(11).Buffer);
                        //book.Photo = Image.FromStream(ms);

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

                        //MemoryStream ms = new MemoryStream(reader.GetSqlBytes(11).Buffer);
                        //book.Photo = Image.FromStream(ms);

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

                        //MemoryStream ms = new MemoryStream(reader.GetSqlBytes(11).Buffer);
                        //book.Photo = Image.FromStream(ms);

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
}
}
