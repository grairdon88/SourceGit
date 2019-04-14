using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.AggregateRoot {
    public class Order : IAggregateRoot{
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }

        public bool IsDeleted { get; set; } = false;

        public List<OrderDetail> OrderDetails { get; set; }

        public Order() {

        }
    }
}
