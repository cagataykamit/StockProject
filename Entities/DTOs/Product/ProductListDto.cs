using Core.Entities;

namespace Entities.DTOs.Product
{
    public class ProductListDto : IDto
    {
        public int Id { get; set; }

        public int IdStockUnit { get; set; }
        public int IdStockClass { get; set; }
        public int IdStockType { get; set; }
        public string StockCode { get; set; }
        public string StockTypeName { get; set; }
        public string StockUnitDescription { get; set; }

        public int Amount { get; set; }

        public decimal TotalAmount { get; set; }

        public int IdShelf { get; set; }

        public int IdCabinet { get; set; }

        public int CriticalAmount { get; set; }

        public bool Deleted { get; set; }
        public string? ShelfCode { get; set; }

        public string? CabinetCode { get; set; }
    }
}