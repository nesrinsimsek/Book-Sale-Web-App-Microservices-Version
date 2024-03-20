using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BookSale.MVC.Models;
using BookSale.MVC.Models.Dtos;
using BookSale.MVC.Services.Abstract;



namespace BookSale.MVC.ViewComponents
{
    public class BookListViewComponent : ViewComponent
    {
        private readonly IBookService _bookService;

        public BookListViewComponent(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {
            List<BookDto> list = new List<BookDto>();

            if (categoryId != 0)
            {
                list = await GetBookListByCategory(categoryId);
            }
            else
            {
                var response = await _bookService.GetAllAsync<ApiResponse>();
                if (response != null && response.IsSuccess)
                {
                    list = JsonConvert.DeserializeObject<List<BookDto>>(Convert.ToString(response.Data));
                }
            }

            return View(list);
        }

        public async Task<List<BookDto>> GetBookListByCategory(int categoryId)
        {
            var list = new List<BookDto>();

            var response = await _bookService.GetByCategoryAsync<ApiResponse>(categoryId);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BookDto>>(Convert.ToString(response.Data));
            }
            return list;
        }
    }


}
