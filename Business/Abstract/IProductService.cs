using Core.Utilities.Results;
using DataAccess.Entities;
using Entities.DTOs.Product;
using MVC.Models;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult? Delete(Product product);

        IDataResult<List<Product>> GetAll();

        IResult Update(Product product);

        IResult? Add(Product product);

        IDataResult<List<ProductDto>> GetAllLiveProduct(RequestGetAllLiveProduct product);
    }
}