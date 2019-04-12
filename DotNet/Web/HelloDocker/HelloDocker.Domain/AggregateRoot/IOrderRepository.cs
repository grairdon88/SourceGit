using System.Threading.Tasks;

namespace HelloDocker.Domain.AggregateRoot
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetByOrderNumber(string orderNumber);
         
    }
}