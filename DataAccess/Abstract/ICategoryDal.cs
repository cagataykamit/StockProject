using Core.DataAccess;
using Core.Utilities.Results;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        List<SelectListItem> GetAllCategorySelectList();

        List<SelectListItem> GetAllCurrencyTypeSelectList();
    }
}