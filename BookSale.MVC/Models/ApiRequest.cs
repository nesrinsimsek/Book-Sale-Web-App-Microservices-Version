using BookSale.MVC.Utility;
using static BookSale.MVC.Utility.SD;

namespace BookSale.MVC.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
        public string Token { get; set; }
    }
}
