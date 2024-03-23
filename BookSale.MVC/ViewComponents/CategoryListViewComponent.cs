using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AutoMapper;
using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;


namespace BookSale.MVC.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {

        private readonly ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {


            List<CategoryDto> list = new();

            var response = await _categoryService.GetAllAsync<ApiResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(response.Data));
            }
            ViewData["CategoryList"] = list;

            return View(list);
        }

    }
}
