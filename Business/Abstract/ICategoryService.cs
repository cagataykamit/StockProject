using Core.Utilities.Results;
using DataAccess.Entities;
using System.Web.Mvc;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult? Delete(Category category);

        IDataResult<List<Category>> GetAll();

        IResult? GetAllForTable();

        IResult Update(Category category);

        IResult? Add(Category category);

        List<SelectListItem> GetAllCategorySelectList();
    }
}