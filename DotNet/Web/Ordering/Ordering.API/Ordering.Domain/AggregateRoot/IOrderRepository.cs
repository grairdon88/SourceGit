using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.AggregateRoot {
    public interface IOrderRepository : IRepository<Order> {
        Order Add(Order order);
        Order GetByOrderNumberAsync(string orderID);

        List<Order> GetList();

        void Delete(string orderNumber);

        Order AddOrderDetail(string orderNumber, OrderDetail orderDetail);
    }
}
