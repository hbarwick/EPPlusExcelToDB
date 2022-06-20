using Dapper.Contrib.Extensions;

namespace EPPlusExcelToDB.Model
{
    [Table("Products")]
    internal class StockItem
    {
        public string Product { get; set; }
        public long Barcodes { get; set; }
        public string? Description { get; set; }
        public int Category { get; set; }
        public int Code { get; set; }
        public float VATRate { get; set; }
        public float RSP { get; set; }
        public float Cost { get; set; }
        public int CaseSize { get; set; }
    }
}
