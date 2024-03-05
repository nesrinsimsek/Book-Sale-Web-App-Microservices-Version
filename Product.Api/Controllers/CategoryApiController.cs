using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Business.Abstract;
using Product.Entity.Dtos;
using Product.Entity.Models;
using System.Net;

namespace Product.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;
        protected ApiResponse _response;

        public CategoryApiController(ICategoryManager categoryManager, IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetList()
        {
            var categories = await _categoryManager.GetCategoryList();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = categoryDtos;
            return Ok(_response);

        }
    }
}
