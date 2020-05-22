using AUT_Market.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace AUT_Market.Service
{
    public class BaseDatabase
    {
        static BaseDatabase baseDatabase;
        public static BaseDatabase Current {
            get => baseDatabase ?? (baseDatabase=new BaseDatabase());
        }
        private static readonly SQLiteAsyncConnection db;
        static BaseDatabase() {
            if (db == null) {
                db = DependencyService.Get<ISQLite>().GetAsyncConnection();
            }
        }
        public async void CreateTableAsync() {
            try
            {
                await db.CreateTableAsync<TestBooks>();
            }
            catch (Exception)
            {

            }
        }

        #region  TestBooks
        public async Task<List<TestBooks>> GetBooks(){
            return await db.Table<TestBooks>().ToListAsync();
        }
        public async Task<List<TestBooks>> GetBooks(bool islike=true)
        {
            return await db.Table<TestBooks>().Where(c => c.Islike == islike).ToListAsync();
        }
        public async Task<TestBooks> GetBook(int Id) {
            return await db.Table<TestBooks>().Where(c=>c.Id==Id).FirstOrDefaultAsync();
        }
        public async Task<int> UpdateBook(TestBooks model) {
            int result = -2;
            var query = await GetBook(model.Id);
            if (query == null)
            {
                result = await db.InsertAsync(model);
            }
            else {
                result = await db.UpdateAsync(model);
            }
            return result;
        }
        public async Task<int> RemoveBook(TestBooks model) {
            var result = GetBook(model.Id);
            if (result != null) {
                return await db.DeleteAsync(model);
            }
            return -1;
        }
        #endregion


    }
}
