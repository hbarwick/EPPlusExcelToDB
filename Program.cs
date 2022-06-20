using EPPlusExcelToDB.Controller;
using EPPlusExcelToDB.Model;
using EPPlusExcelToDB.Reader;
using OfficeOpenXml;


DBController db = new();
db.CreateDatabase();

string file = @".\PriceFile.xlsx";
var prices = ReadSheet(file);
db.WriteRowsToDatabase(prices);

var pricesFromDb = db.ReadRowsFromDatabase();

Report.DisplayStockReport(pricesFromDb);

static List<StockItem> ReadSheet(string file)
{
    Console.WriteLine($"Reading Excel file {file}");
    using (var package = new ExcelPackage(new FileInfo(file)))
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        var sheet = package.Workbook.Worksheets[0];
        var priceFile = new Reader().GetList<StockItem>(sheet);

        return priceFile;
    }
}

