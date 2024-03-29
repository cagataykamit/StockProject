using DataAccess.Entities;
using Entities.DTOs.Product;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models
{
    public class ProductViewModel
    {
        public List<ProductDto>? ProductList { get; set; }

        public List<SelectListItem> CategoryItems { get; set; }

        public int ProductId { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public int? Quantity { get; set; }

        public int? CategoryId { get; set; }
    }
}