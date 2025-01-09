using System;
using PROIECT.Data;
using System.IO;

namespace PROIECT
{
    public partial class App : Application
    {
        // Instanta bazei de date
        static PlayerListDatabase database;

        // Proprietatea pentru accesarea bazei de date
        public static PlayerListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    // Obtinerea caii bazei de date
                    string dbPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "PlayerList.db3");

                    // Afisarea caii bazei de date in consola
                    Console.WriteLine($"Database Path: {dbPath}");

                    // Initializeaza baza de date
                    database = new PlayerListDatabase(dbPath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            // Seteaza pagina principala a aplicatiei
            MainPage = new AppShell();
        }
    }
}