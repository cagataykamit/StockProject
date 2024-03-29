using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Entities;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, StockContext>, ICategoryDal
    {
        public List<SelectListItem> GetAllCategorySelectList()
        {
            using (StockContext context = new StockContext())
            {
                var result = from s in context.Categories
                             select new SelectListItem
                             {
                                 Text = s.Title,
                                 Value = s.CategoryId.ToString()
                             };
                return result.ToList();
            }
        }

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
    }
}