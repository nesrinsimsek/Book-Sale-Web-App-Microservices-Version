using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json;
using AutoMapper;
using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;
using BookSale.MVC.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace BookSale.MVC.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryListViewComponent(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
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
