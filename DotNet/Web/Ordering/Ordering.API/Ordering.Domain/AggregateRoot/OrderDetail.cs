using System;
using System.Collections.Generic;
using System.Text;
namespace Ordering.Domain.AggregateRoot {
    public class OrderDetail {
        public int OrderDetailID { get; set; }

        private int OrderID { get; set; }

        public int LineNumber { get; set; } = 0;

        public string Description { get; set; }

        public decimal Price { get; set; } = 0.0M;

        public bool IsDeleted { get; set; } = false;

        public OrderDetail() {

        }

        public void SetOrderID(int orderID) {
            OrderID = orderID;
        }
    }
}
