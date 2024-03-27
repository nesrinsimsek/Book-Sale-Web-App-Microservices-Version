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
        [NotMapped]
        public HttpStatusCode StatusCode { get; set; }
        [NotMapped]
        public bool IsSuccess { get; set; }
        [NotMapped]
        public List<string> ErrorMessages { get; set; }
        public object Data { get; set; }
        public DateTime Date { get; }
        public ApiResponse()
        {
            IsSuccess = true;
            ErrorMessages = new List<string>();
            Date = DateTime.Now;
        }

    }
}
