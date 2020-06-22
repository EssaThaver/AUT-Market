using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace AUT_Market.Service
{
    class Email
    {
        private Book book;

        //------------------------------------------------------------------------------------------------------------------------------------//
        public Boolean sendMesseage (Book getbook)
        {
            book = getbook;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("autmarket.noreply@gmail.com");
                mail.To.Add(book.ShopEmailAddress.Trim());
                mail.Subject = this.subject();
                mail.Body = this.body();
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("autmarket.noreply@gmail.com", "aucklandUT");


                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        //------------------------------------------------------------------------------------------------------------------------------------//
        public string subject()
        {
            string subMsg = User.Name + " is interested your book \"" + book.Title + "\"";
            return subMsg;
        }

        //------------------------------------------------------------------------------------------------------------------------------------//
        public string body ()
        {

            string bodyMsg =
                "Hi " + book.ShopUserName + ", \n\n" +
                User.Name + " is interested in buying your book.\n\n" +
                "Title: " + book.Title +
                "\nAuthor: " + book.Author +
                "\nCourse Code: " + book.CourseCode +
                "\n\nThis is "+ User.Name +"'s email address: " + User.Email;

            return bodyMsg;
        }
    }
}
