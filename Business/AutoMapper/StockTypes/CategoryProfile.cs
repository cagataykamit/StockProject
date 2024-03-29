using AutoMapper;
using DataAccess.Entities;
using Entities.DTOs.Category;

namespace Business.AutoMapper.CategoryTypes
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}