using EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntity.Entities
{
    public class OrderBook : IEntity
    {
      
        public int Order_Id { get; set; }    
        public int Book_Id { get; set; }
        public int Quantity { get; set; }
    }
}
