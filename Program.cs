
using EPPlusExcelToDB.Controller;
using EPPlusExcelToDB.Model;
using EPPlusExcelToDB.Reader;
using OfficeOpenXml;

string file = @".\PriceFile.xlsx";

using (var package = new ExcelPackage(new FileInfo(file)))
{
    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    var sheet = package.Workbook.Worksheets[0];
    var priceFile = new Reader().GetList<StockItem>(sheet);
}


DBController db = new();

db.CreateDatabase();