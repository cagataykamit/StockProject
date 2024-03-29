using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Entities;
using DataAccess.EntityFramework;
using Entities.DTOs.Product;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, StockContext>, IProductDal
    {
        public List<SelectListItem> GetAllCurrencyTypeSelectList()
        {
            using (StockContext context = new StockContext())
            {
                var result = from s in context.Categories
                             select new SelectListItem
                             {
                                 Value = s.CategoryId.ToString()
                             };
                return result.ToList();
            }
        }

        public List<ProductDto> GetAllLiveProduct(RequestGetAllLiveProduct product)
        {
            using (StockContext context = new StockContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryId equals c.CategoryId
                             where
                             p.Quantity > c.MinimumQuantity
                             && p.Deleted == false

                              && (product.MinQuantity == null || product.MaxQuantity != null || p.Quantity >= product.MinQuantity)

                              && (product.MaxQuantity == null || product.MinQuantity != null || p.Quantity <= product.MaxQuantity)

                              && (product.MinQuantity == null || product.MaxQuantity == null || p.Quantity >= product.MinQuantity && p.Quantity <= product.MaxQuantity)

                              && (product.Query == null || p.Title.Contains(p.Title))

                              && (product.Query == null || p.Title.Contains(p.Description))

                              && (product.Query == null || p.Title.Contains(c.Title))

                             select new ProductDto
                             {
                                 Title = p.Title,
                                 CategoryId = c.CategoryId,
                                 CategoryName = c.Title,
                                 Description = p.Description,
                                 Quantity = p.Quantity,
                                 ProductId = p.ProductId
                             };
                return result.ToList();
            }
        }
    }
}