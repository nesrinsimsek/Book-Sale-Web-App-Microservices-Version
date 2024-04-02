using Innofactor.EfCoreJsonValueConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.MVC.Models 
{ 
    public class ApiResponse
    {
        public int Id { get; set; }
        [JsonField]
        public object? Data { get; set; }
        public DateTime ResponseDate { get; set; }
        public ApiResponse()
        {
            IsSuccess = true;
            ErrorMessages = new List<string>();
            ResponseDate = DateTime.Now;
        }

        [NotMapped]
        public HttpStatusCode StatusCode { get; set; }
        [NotMapped]
        public bool IsSuccess { get; set; }
        [NotMapped]
        public List<string> ErrorMessages { get; set; }
    }
}
