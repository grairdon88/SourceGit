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

        public async Task<Order> GetByOrderNumberAsync (string orderNumber, string hostAddress) {
            using(SqlConnection conn = new SqlConnection(_connectionString)){
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@OrderNumber", orderNumber, System.Data.DbType.String, System.Data.ParameterDirection.Input, 50);
                parameters.Add("@HostAddress", hostAddress, System.Data.DbType.String, System.Data.ParameterDirection.Input, 500);
                return await conn.QuerySingleAsync<Order>("dbo.upGetOrderByOrderNumber", parameters, null, 30, System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task CreateOrder(Order newOrder, string hostAddress) {
            using (SqlConnection conn = new SqlConnection(_connectionString)) {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@OrderNumber", newOrder.OrderNumber, System.Data.DbType.String, System.Data.ParameterDirection.Input, 50);
                parameters.Add("@HostAddress", hostAddress, System.Data.DbType.String, System.Data.ParameterDirection.Input, 500);

                await conn.QueryAsync("dbo.upCreateOrder", parameters, null, 30, System.Data.CommandType.StoredProcedure);
            }
        }
    }
}