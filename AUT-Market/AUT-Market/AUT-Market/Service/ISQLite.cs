using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AUT_Market.Service
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetAsyncConnection();
    }
}
