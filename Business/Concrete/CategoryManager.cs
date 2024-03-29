using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Entities;
using System.Web.Mvc;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            category.Deleted = false;
            _categoryDal.Add(category);

            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult? Delete(Category category)
        {
            var objCategory = _categoryDal.Get(x => x.CategoryId == category.CategoryId);

            _categoryDal.Delete(objCategory);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoryListed);
        }

        public List<SelectListItem> GetAllCategorySelectList()
        {
            return _categoryDal.GetAllCategorySelectList();
        }

        public IResult? GetAllForTable()
        {
            throw new NotImplementedException();
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(Category Category)
        {
            var objCategory = _categoryDal.Get(x => x.CategoryId == Category.CategoryId);

            objCategory.Title = Category.Title;
            objCategory.Deleted = Category.Deleted;

            _categoryDal.Update(objCategory);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}