using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Potor_Raul_Adrian_Proiect.Models;
using SQLite;

namespace Potor_Raul_Adrian_Proiect.Data
{
    public class WatchListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public WatchListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<WatchList>().Wait();
            _database.CreateTableAsync<Movie>().Wait();
            _database.CreateTableAsync<ListMovie>().Wait();
        }
        public Task<List<WatchList>> GetWatchListsAsync()
        {
            return _database.Table<WatchList>().ToListAsync();
        }
        public Task<WatchList> GetWatchListAsync(int id)
        {
            return _database.Table<WatchList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveWatchListAsync(WatchList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteWatchListAsync(WatchList slist)
        {
            return _database.DeleteAsync(slist);
        }

        public Task<int> SaveMovieAsync(Movie product)
        {
            if (product.ID != 0)
            {
                return _database.UpdateAsync(product);
            }
            else
            {
                return _database.InsertAsync(product);
            }
        }
        public Task<int> DeleteMovieAsync(Movie product)
        {
            return _database.DeleteAsync(product);
        }
        public Task<List<Movie>> GetMoviesAsync()
        {
            return _database.Table<Movie>().ToListAsync();
        }

        public Task<int> SaveListMovieAsync(ListMovie lstmv)
        {
            if (lstmv.ID != 0)
            {
                return _database.UpdateAsync(lstmv);
            }
            else
            {
                return _database.InsertAsync(lstmv);
            }
        }
        public Task<List<Movie>> GetListMoviesAsync(int watchlistid)
        {
            return _database.QueryAsync<Movie>(
            "select P.ID, P.Description from Movie P"
            + " inner join ListMovie LP"
            + " on P.ID = LP.MovieID where LP.WatchListID = ?",
            watchlistid);
        }

    }
}
