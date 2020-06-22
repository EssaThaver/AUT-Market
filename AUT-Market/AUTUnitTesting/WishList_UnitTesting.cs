using AUT_Market;
using AUT_Market.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AUTUnitTesting
{
    /// <summary>
    /// Unit Testing for Add books to WishList
    /// </summary>
    [TestClass]
    public class WishList_UnitTesting
    {
        BookVaildation vaildation = new BookVaildation();

        string listingnumber = "7BCD8CBD-0FB1-EA11-9B05-2818783A89BE";
        string title = "Software Development";
        string author = "Mac";
        string faculty= "Design and Creative Technologies";
        string price = "86";
        string courseCode = "602";
        string desc = "Software Development Book";


        [TestMethod]
        public void TestMethod1() {
            AddBooksNew();
        }
        private void AddBooksNew() {
            Book model = new Book() {Title = title, Author = author, CourseCode = courseCode, Price = price, Description = desc };
            var result = vaildation.AddBook(model);
            Assert.IsTrue(result);
        }
    }
}
