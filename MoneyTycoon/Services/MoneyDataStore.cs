using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoneyTycoon.Models;
using SQLite;

namespace MoneyTycoon.Services
{
    public class MoneyDataStore
    {
        public readonly IEnumerable<Transaction> tx;

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public MoneyDataStore()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Transaction).Name)
                    || !Database.TableMappings.Any(m => m.MappedType.Name == typeof(Bank).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Transaction)).ConfigureAwait(false);
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Bank)).ConfigureAwait(false);
                        
                    if (await Database.Table<Bank>().CountAsync() is 0)
                        await Database.InsertAsync(new Bank());
                    if (await Database.Table<Transaction>().CountAsync() is 0)
                        await Database.InsertAsync(new Transaction());
                    initialized = true;
                }
            }
        }

        public async Task<int> AddBalanceTransaction(Transaction ta)
        {
            return await Database.InsertAsync(ta);
        }

        public async Task<Bank> GetBalance()
        {
            return await Database.Table<Bank>().FirstOrDefaultAsync();
        }

        public async Task<List<Transaction>> GetTransactions()
        {
            var txs = await Database.Table<Transaction>().ToListAsync();

            return txs;
        }

        public Task DeleteTransaction(Transaction ta)
        {
            return Database.DeleteAsync(ta);
        }   
    }
}