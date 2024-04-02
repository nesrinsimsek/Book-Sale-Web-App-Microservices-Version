using BookSale.MVC.Contexts;
using BookSale.MVC.Models;
using BookSale.MVC.Services.Abstract;

namespace BookSale.MVC.Services.Concrete
{
    public class HttpResponseLogService : IHttpResponseLogService
    {
        private readonly AppDbContext _context;
        public HttpResponseLogService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(ApiResponse apiResponse)
        {
            _context.Responses.Add(apiResponse);
            _context.SaveChanges();
        }
    }
}
