using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using PROIECT.Models;

namespace PROIECT.Data
{
    public class PlayerListDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public PlayerListDatabase(string dbPath)
        {
            // Crearea conexiunii la baza de date
            _database = new SQLiteAsyncConnection(dbPath);

            // Crearea tabelelor dacă nu există
            _database.CreateTableAsync<Player>().Wait();
            _database.CreateTableAsync<Team>().Wait();
        }

        // -------------------- Funcții pentru Player --------------------

        // Obține toți jucătorii
        public Task<List<Player>> GetPlayersAsync()
        {
            return _database.Table<Player>().ToListAsync();
        }

        // Obține un jucător după ID
        public Task<Player> GetPlayerAsync(int id)
        {
            return _database.FindAsync<Player>(id);
        }

        // Salvează sau actualizează un jucător
        public Task<int> SavePlayerAsync(Player player)
        {
            if (player.PlayerId != 0)
            {
                return _database.UpdateAsync(player);
            }
            else
            {
                return _database.InsertAsync(player);
            }
        }

        // Șterge un jucător
        public Task<int> DeletePlayerAsync(Player player)
        {
            return _database.DeleteAsync(player);
        }

        // Obține jucătorii unei echipe după ID-ul echipei
        public Task<List<Player>> GetPlayersByTeamIdAsync(int teamId)
        {
            return _database.Table<Player>().Where(p => p.TeamId == teamId).ToListAsync();
        }

        // -------------------- Funcții pentru Team --------------------

        // Obține toate echipele
        public Task<List<Team>> GetTeamsAsync()
        {
            return _database.Table<Team>().ToListAsync();
        }

        // Obține o echipă după ID
        public Task<Team> GetTeamAsync(int id)
        {
            return _database.FindAsync<Team>(id);
        }

        // Salvează sau actualizează o echipă
        public Task<int> SaveTeamAsync(Team team)
        {
            if (team.TeamId != 0)
            {
                return _database.UpdateAsync(team);
            }
            else
            {
                return _database.InsertAsync(team);
            }
        }

        // Șterge o echipă
        public Task<int> DeleteTeamAsync(Team team)
        {
            return _database.DeleteAsync(team);
        }
        public async Task DeleteDatabaseAsync()
        {
            try
            {
                // Închide conexiunea activă la baza de date
                await _database.CloseAsync();

                // Obține calea bazei de date
                string dbPath = _database.DatabasePath;

                // Verifică dacă baza de date există
                if (File.Exists(dbPath))
                {
                    File.Delete(dbPath); // Șterge fișierul bazei de date
                    Console.WriteLine("Database deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Database not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting database: {ex.Message}");
            }
        }

    }
}
