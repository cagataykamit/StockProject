using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Product
{
    public class ProductDto : IDto
    {
        public int? ProductId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public int? Quantity { get; set; }

        public int? CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }
}