using System.Threading.Tasks;

namespace HelloDocker.Domain.AggregateRoot
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetByOrderNumberAsync(string orderNumber, string hostAddress);
        Task CreateOrder(Order newOrder, string hostAddress);
    }
}