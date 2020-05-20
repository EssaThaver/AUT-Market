using AUT_Market.Droid;
using AUT_Market.Service;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace AUT_Market.Droid
{
    class SQLite_Android : ISQLite
    {
        private static SQLiteAsyncConnection connectionAsync;
        private static string path;
        private static readonly object locker = new object();
        private static readonly object pathLocker = new object();
        public SQLiteAsyncConnection GetAsyncConnection()
        {
            lock (locker) {
                if (connectionAsync == null) {
                    var dbPath = GetDatabasePath();
                    connectionAsync = new SQLiteAsyncConnection(dbPath);
                }
            }
            return connectionAsync;
        }
        private static string GetDatabasePath()
        {
            lock (pathLocker)
            {
                if (path == null)
                {
                    const string sqliteFilename = "xamcnblogs.db3";
                    string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                    path = Path.Combine(documentsPath, sqliteFilename);
                }
            }
            return path;
        }

    }
}