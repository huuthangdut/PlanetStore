using System;
using System.Collections.Generic;
using Planet.Data.Core.Domain;

namespace Planet.Services.Core
{
    public interface IOrderService
    {
        Order Add(Order order);

        void Update(Order order);

        Order GetById(int id);

        IEnumerable<Order> GetMostRecentOrders(int howMany);

        IEnumerable<Order> GetOrdersByStatus(int statusId);

        IEnumerable<Order> GetOrdersByCustomerId(string id);

        IEnumerable<Order> GetOrdersBetweenDates(DateTime startDate, DateTime endDate);

    }
}
