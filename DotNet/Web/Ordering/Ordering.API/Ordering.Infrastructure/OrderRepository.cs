using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ordering.Domain.AggregateRoot;
using Microsoft.EntityFrameworkCore;

namespace Ordering.Infrastructure {
    public class OrderRepository : IOrderRepository {
        private readonly OrderingContext _context;
        public OrderRepository(OrderingContext context) {
            _context = context ?? throw new ArgumentException(nameof(context));
            _context.Database.EnsureCreated();
        }

        public Order Add(Order order) {


            Order newOrder = _context.Orders.Add(order).Entity;

            _context.SaveChanges();
            return newOrder;

        }

        public Order GetByOrderNumberAsync(string orderNumber) {
            Order order = _context.Orders.First(o => o.OrderNumber == orderNumber);

            return order;
        }

        public List<Order> GetList() {
            return _context.Orders.Where(order => order.IsDeleted == false).ToList();
        }

        public Order AddOrderDetail(string orderNumber, OrderDetail orderDetail) {
            Order order = _context.Orders.Single(o => o.OrderNumber == orderNumber);

            orderDetail.SetOrderID(order.OrderID);

            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();

            return _context.Orders.Include(b => b.OrderDetails).Single(o => o.OrderNumber == orderNumber);
        }

        public void Delete(string orderNumber) {
            Order deletedOrder = _context.Orders.First(o => o.OrderNumber == orderNumber);

            deletedOrder.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
