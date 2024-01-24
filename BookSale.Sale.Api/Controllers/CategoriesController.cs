using AutoMapper;
using BookSale.Sale.Business.Abstract;
using BookSale.Sale.Entities.Concrete;
using BookSale.Sale.Entities.Concrete.Dtos;
using BookSale.Sale.Entities.Concrete.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookSale.Sale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        protected ApiResponse _response;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _response = new ();
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetList()
        {
            var categories = await _categoryService.GetCategoryList();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = categoryDtos;
            return Ok(_response);

        }
    }
}
