﻿using OrderEntity.CartModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntity.CartModels.Concrete
{
    public class Cart : ICartModel
    {
        public List<CartLine> CartLines { get; set; }
        public decimal TotalPrice
        {
            get { return CartLines.Sum(c => c.Quantity * c.Book.Price); }
        }

        public Cart()
        {
            CartLines = new List<CartLine>();
        }
    }
}
