using Ratio.Infrastructure.Repositories.Models;
using SQLite;

namespace Ratio.Infrastructure.Services
{
    public class InitialInsertsService
    {
        private readonly SQLiteAsyncConnection _db;

        public InitialInsertsService(SQLiteAsyncConnection db)
        {
            _db = db;
        }

        public async Task ResetDBAsync()
        {
            await DropTablesAsync();
            await CreateTablesAsync();
        }

        private async Task DropTablesAsync()
        {
            await _db.DropTableAsync<PloyDataModel>();
            await _db.DropTableAsync<WeaponTraitDataModel>();
            await _db.DropTableAsync<OperativeWeaponDataModel>();
            await _db.DropTableAsync<WeaponDataModel>();
            await _db.DropTableAsync<OperativeDataModel>();
            await _db.DropTableAsync<KillTeamDataModel>();
            await _db.DropTableAsync<FactionDataModel>();
        }

        private async Task CreateTablesAsync()
        {
            await _db.CreateTableAsync<FactionDataModel>();
            await _db.CreateTableAsync<KillTeamDataModel>();
            await _db.CreateTableAsync<OperativeDataModel>();
            await _db.CreateTableAsync<WeaponDataModel>();
            await _db.CreateTableAsync<WeaponTraitDataModel>();
            await _db.CreateTableAsync<OperativeWeaponDataModel>();
            await _db.CreateTableAsync<PloyDataModel>();
        }


        public async Task ExecuteSeedScriptAsync(IEnumerable<string> sqlLines)
        {
            try
            {
                await Parallel.ForEachAsync(sqlLines, new ParallelOptions { MaxDegreeOfParallelism = 4 }, async (line, _) =>
                {
                    await _db.ExecuteAsync(line);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing provided SQL lines: {ex.Message}");
                throw;
            }
        }

    }
}
