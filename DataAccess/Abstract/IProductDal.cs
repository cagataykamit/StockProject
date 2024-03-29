using Core.DataAccess;
using Core.Utilities.Results;
using DataAccess.Entities;
using Entities.DTOs.Product;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<SelectListItem> GetAllCurrencyTypeSelectList();

        List<ProductDto> GetAllLiveProduct(RequestGetAllLiveProduct product);
    }
}