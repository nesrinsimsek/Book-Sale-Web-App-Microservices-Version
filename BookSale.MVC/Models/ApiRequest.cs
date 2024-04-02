using BookSale.MVC.Utility;
using Innofactor.EfCoreJsonValueConverter;
using System.ComponentModel.DataAnnotations.Schema;
using static BookSale.MVC.Utility.SD;

namespace BookSale.MVC.Models
{
    public class ApiRequest
    {
        public int Id { get; set; }

        public string Url { get; set; }
        [JsonField]
        public object? Data { get; set; }    
        public DateTime RequestDate { get; set; }
        public ApiRequest()
        {
            RequestDate = DateTime.Now;
        }
        [NotMapped]
        public string Token { get; set; }
        [NotMapped]
        public ApiType ApiType { get; set; }
    }
}
