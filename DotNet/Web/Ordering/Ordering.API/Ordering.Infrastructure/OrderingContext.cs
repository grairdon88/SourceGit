using Microsoft.EntityFrameworkCore;
using Ordering.Domain.AggregateRoot;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Ordering.Infrastructure {
    public class OrderingContext : DbContext {
        public const string DefaultSchema = "Ordering";
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public OrderingContext(DbContextOptions<OrderingContext> options) : base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");
        }
    }
}
