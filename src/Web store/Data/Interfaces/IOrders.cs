using Web_store.Data.Models;

namespace Web_store.Data.Interfaces
{
    public interface IOrders
    {
        void CreateOrder(Order order);
    }
}
