using AutoMapper;
using DataAccess.Entities;
using Entities.DTOs.Category;
using Entities.DTOs.Product;

namespace Business.AutoMapper.StockTypes
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}