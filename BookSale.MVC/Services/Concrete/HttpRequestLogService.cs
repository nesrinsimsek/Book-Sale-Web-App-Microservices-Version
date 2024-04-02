using BookSale.MVC.Contexts;
using BookSale.MVC.Models;
using BookSale.MVC.Services.Abstract;

namespace BookSale.MVC.Services.Concrete
{
    public class HttpRequestLogService : IHttpRequestLogService
    {
        // EntityRepository extend edilecek
        // EntityRepository'deki add metodu çağrılacak

        private readonly AppDbContext _context;
        public HttpRequestLogService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(ApiRequest apiRequest)
        {
            _context.Requests.Add(apiRequest);
            _context.SaveChanges();
        }
    }
}
