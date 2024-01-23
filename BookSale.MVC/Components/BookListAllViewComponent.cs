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
    public class BookListAllViewComponent :ViewComponent
    {

        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookListAllViewComponent(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<BookDto> list = new();

            var response = await _bookService.GetAllAsync<ApiResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BookDto>>(Convert.ToString(response.Data));
            }
            return View(list);
        }
    }
}
