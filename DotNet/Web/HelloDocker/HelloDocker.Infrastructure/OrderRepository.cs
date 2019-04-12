using System;
using System.Threading.Tasks;
using HelloDocker.Domain.AggregateRoot;
using Dapper;
using System.Data.SqlClient;

namespace HelloDocker.Infrastructure {
    public class OrderRepository : IOrderRepository {
        private string _connectionString = null;

        public OrderRepository (string connectionString) {
            _connectionString = connectionString;
        }

        public Task<Order> GetByOrderNumber (string orderNumber) {
            using(SqlConnection conn = new SqlConnection()){
                return null;
            }
        }
    }
}