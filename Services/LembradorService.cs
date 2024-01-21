using Lembrador.Model;
using MonkeyCache.LiteDB;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lembrador.Services
{
    public class LembradorService
    {
        private const string DB_NAME = "db_lembretes.db3";
        private readonly SQLiteAsyncConnection _connection;
        public LembradorService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Lembrete>();
        }

        public Task<List<Lembrete>> RetornaLembretes()
        {
            return _connection.Table<Lembrete>().ToListAsync();
        }


    }
}
