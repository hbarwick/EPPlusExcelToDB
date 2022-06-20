using ConsoleTableExt;
using EPPlusExcelToDB.Model;

namespace EPPlusExcelToDB.Controller
{
    internal class Report
    {
        public static void DisplayStockReport(List<StockItem> stockList)
        {
            Console.WriteLine("\nReport of lines read from database...\n");
            var tableData = new List<List<object>>();

            foreach (StockItem stock in stockList)
            {
                tableData.Add(new List<object> { 
                    stock.Description, 
                    stock.Barcodes, 
                    stock.Product,
                    stock.RSP.ToString("0.00"),
                    stock.Cost.ToString("0.00"),
                    stock.VATRate.ToString("0.00"),
                });
                    
            }
            ConsoleTableExt.ConsoleTableBuilder
                .From(tableData)
                .WithColumn("Description", "Barcode", "Product code", "RSP", "Cost", "VAT Rate")
                .ExportAndWriteLine();
        }
    }
}
