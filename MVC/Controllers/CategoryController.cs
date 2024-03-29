using Business.Abstract;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;

namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _CategoryService;

        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var viewModel = new CategoryViewModel();

            var result = _CategoryService.GetAll();
            if (result.Success)
            {
                viewModel.CategoryList = result.Data;
                //return Ok(result);
                return View(viewModel);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            var result = _CategoryService.Add(category);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        public IActionResult Update()
        {
            return PartialView("_UpdateCategoryPartialView");
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            var result = _CategoryService.Update(category);
            if (result.Success)
            {
                return RedirectToAction("GetAll", new { message = result.Message });
            }
            else
            {
                return PartialView("_UpdateCategoryPartialView", category);
            }
        }

        [HttpGet]
        public IActionResult Delete(Category category)
        {
            var result = _CategoryService.Delete(category);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}