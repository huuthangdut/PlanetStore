using System;
using System.Collections.Generic;
using Planet.Data.Core.Domain;
using Planet.Data.Core.Repositories;
using Planet.Services.Core;

namespace Planet.Services.Persistence
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Add(Order order)
        {
            return _orderRepository.Add(order);
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }

        public Order GetById(int id)
        {
            return _orderRepository.Find(id);
        }

        public IEnumerable<Order> GetMostRecentOrders(int howMany)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersByStatus(int statusId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersByCustomerId(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersBetweenDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
