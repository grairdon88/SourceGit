using System;

namespace HelloDocker.Domain.AggregateRoot {
    public class Order : IAggregateRoot{
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; } = 0.0M;
    }
}