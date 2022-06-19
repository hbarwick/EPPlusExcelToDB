using System.Configuration;
using System.Data.SQLite;

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
            command.ExecuteNonQuery();

        }
    }
}
