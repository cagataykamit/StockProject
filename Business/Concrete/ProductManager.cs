using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Entities;
using Entities.DTOs.Product;
using MVC.Models;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            product.Deleted = false;
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var objProduct = _productDal.Get(x => x.ProductId == product.ProductId);

            objProduct.Title = product.Title;
            objProduct.Description = product.Description;
            objProduct.Quantity = product.Quantity;
            objProduct.Deleted = product.Deleted;

            _productDal.Update(objProduct);
            return new SuccessResult(Messages.CategoryUpdated);
        }

        public IResult? Delete(Product product)
        {
            var objProduct = _productDal.Get(x => x.ProductId == product.ProductId);

            _productDal.Delete(objProduct);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<ProductDto>> GetAllLiveProduct(RequestGetAllLiveProduct product)
        {
            return new SuccessDataResult<List<ProductDto>>(_productDal.GetAllLiveProduct(product), Messages.ProductListed);
        }
    }
}