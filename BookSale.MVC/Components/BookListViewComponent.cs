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


namespace BookSale.MVC.Components
{
    public class BookListViewComponent :ViewComponent
    {

        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookListViewComponent(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {
            if (categoryId != 0)
            {
                
                return View(GetBookListByCategory(categoryId));
            }

            List<BookDto> list = new();

            var response = await _bookService.GetAllAsync<ApiResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BookDto>>(Convert.ToString(response.Data));
            }
            return View(list);
        }

        public async Task<IEnumerable<BookDto>> GetBookListByCategory(int categoryId)
        {

            List<BookDto> list = new();

            var response = await _bookService.GetByCategoryAsync<ApiResponse>(categoryId);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BookDto>>(Convert.ToString(response.Data));
            }
            return list;
        }

    }
}
