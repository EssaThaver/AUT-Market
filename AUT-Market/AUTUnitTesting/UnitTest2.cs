using AUT_Market;
using AUT_Market.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTUnitTesting
{
    /// <summary>
    /// Books收藏测试用例
    /// </summary>
    [TestClass]
    public class UnitTest2
    {
        BookVaildation vaildation = new BookVaildation();
        
        string listingnumber = "";

        [TestMethod]
        public void TestMethod1() {
            this.AddBooksNUll();
            this.AddBooksNew();
            this.AddBooks();
        }
        private void AddBooksNUll() {
            var result = vaildation.AddBook(null);
            Assert.IsTrue(result);
        }
        private void AddBooksNew() {
            var result = vaildation.AddBook(new Book());
            Assert.IsTrue(result);
        }
        private void AddBooks()
        {
            var result = vaildation.AddBook(new Book() { Title="Title",Author= "Author", ListingNumber=Guid.NewGuid()});
            Assert.IsTrue(result);
        }
    }
}
