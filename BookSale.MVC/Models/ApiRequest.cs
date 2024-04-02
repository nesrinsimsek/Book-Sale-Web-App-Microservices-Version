using BookSale.MVC.Utility;
using System.ComponentModel.DataAnnotations.Schema;
using static BookSale.MVC.Utility.SD;

namespace BookSale.MVC.Models
{
    public class ApiRequest
    {
        public int Id { get; set; }
        [NotMapped]
        public ApiType ApiType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }

        [NotMapped]
        public string Token { get; set; }

        public DateTime Date { get; }
        public ApiRequest()
        {
            Date = DateTime.Now;
        }
    }
}
