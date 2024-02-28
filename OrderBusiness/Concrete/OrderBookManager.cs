﻿using OrderBusiness.Abstract;
using OrderDataAccess.Abstract;
using OrderEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBusiness.Concrete
{
    public class OrderBookManager : IOrderBookManager
    {

        private readonly IOrderBookDal _orderBookDal;

        public OrderBookManager(IOrderBookDal orderBookDal)
        {
            _orderBookDal = orderBookDal;
        }
        public async Task AddOrderBook(OrderBook orderBook)
        {
            await _orderBookDal.Add(orderBook);
        }

        public async Task<List<OrderBook>> GetOrderBookList()
        {
            return await _orderBookDal.GetList();
        }
    }
}
