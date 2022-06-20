using System.Configuration;
using System.Data.SQLite;
using Dapper.Contrib.Extensions;
using Dapper;
using EPPlusExcelToDB.Model;

namespace EPPlusExcelToDB.Controller
{
    internal class DBController
    {
        string? connectionString = ConfigurationManager.AppSettings.Get("connectionString");
        public void CreateDatabase()
        {
            var dbfile = @".\ExcelData.db";
            if (File.Exists(dbfile))
            {
                Console.WriteLine("\nDropping old database...");
                File.Delete(dbfile);
            }

            using var connection = new SQLiteConnection(connectionString);
            using var command = connection.CreateCommand();
            connection.Open();

            command.CommandText = @"CREATE TABLE IF NOT EXISTS Products (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Barcodes INTEGER,
                                    Description TEXT,
                                    Category INTEGER,
                                    Code INTEGER,
                                    VATRate REAL,
                                    RSP REAL,
                                    Cost REAL,
                                    CaseSize INTEGER,
                                    Product TEXT
                                    )";
            Console.WriteLine("\nCreating database and tables...");
            command.ExecuteNonQuery();
        }

        public void WriteRowsToDatabase(List<StockItem> stockList)
        {
            Console.WriteLine("\nWriting item list to database...");
            using var connection = new SQLiteConnection(connectionString);
            foreach(StockItem stock in stockList)
            {
                connection.Insert(stock);
            }
        }

        public List<StockItem> ReadRowsFromDatabase()
        {
            Console.WriteLine("\nReading lines from database...\n");
            var stock = new List<StockItem>();
            using var connection = new SQLiteConnection(connectionString);
            stock = connection.Query<StockItem>("SELECT * FROM Products").ToList();
            return stock;
        }

    }
}
