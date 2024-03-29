using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Product
{
    public class RequestProductDto : IDto
    {
        public int? ProductId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public int? Quantity { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }
}