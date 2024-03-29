using DataAccess.Entities;
using Entities.DTOs.StockList;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models
{
    public class CategoryViewModel
    {
        public List<Category>? CategoryList { get; set; }
    }
}