using AUT_Market.Model;
using AUT_Market.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market.ViewModel
{
    class TestBooksViewModel
    {
        public List<TestBooks> getBooks { get; set; }

        public TestBooksViewModel()
        {
            getBooks = new BooksTempDB().GetBooks();
        }
    }
}
