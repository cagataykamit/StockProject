using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Entities;
using Entities.DTOs.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult GetAll(RequestGetAllLiveProduct? product)
        {
            var viewModel = new ProductViewModel();

            var result = _productService.GetAllLiveProduct(product);
            if (result.Success)
            {
                viewModel.ProductList = result.Data;

                viewModel.CategoryItems = new List<SelectListItem>();

                var categoryItems = _categoryService.GetAllCategorySelectList();

                foreach (var item in categoryItems)
                {
                    viewModel.CategoryItems.Add(new SelectListItem { Value = item.Value, Text = item.Text });
                }

                return View(viewModel);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var viewModel = new ProductViewModel();

            var result = _productService.GetAllLiveProduct(new RequestGetAllLiveProduct());
            if (result.Success)
            {
                viewModel.ProductList = result.Data;

                viewModel.CategoryItems = new List<SelectListItem>();

                var categoryItems = _categoryService.GetAllCategorySelectList();

                foreach (var item in categoryItems)
                {
                    viewModel.CategoryItems.Add(new SelectListItem { Value = item.Value, Text = item.Text });
                }

                return View(viewModel);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost]
        public IActionResult GetAllLiveProduct(RequestGetAllLiveProduct product)
        {
            IDataResult<List<ProductDto>> result = _productService.GetAllLiveProduct(product);
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
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        public IActionResult Update()
        {
            return PartialView("_UpdateProductPartialView");
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                return PartialView("_UpdateProductPartialView", product);
            }
        }

        [HttpGet]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}