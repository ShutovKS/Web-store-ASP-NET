using Web_store.Data.Interfaces;
using Web_store.Data.Models;
using Web_store.Migrations;

namespace Web_store.Data.Repositories
{
    public class OrdersReposytory : IOrders
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ShopCart _shopCart;

        public OrdersReposytory(ApplicationDbContext applicationDbContext, ShopCart shopCart)
        {
            _applicationDbContext = applicationDbContext;
            _shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            _applicationDbContext.Order.Add(order);
            _applicationDbContext.SaveChanges();

            var itemsInCart = _shopCart.ItemsInCart;

            foreach (var itemInCart in itemsInCart)
            {
                var orderDetail = new OrderDetail
                {
                    ItemId = itemInCart.Item.Id,
                    OrderId = order.Id,
                    Price = itemInCart.Item.Price
                };

                _applicationDbContext.OrderDetail.Add(orderDetail);
            }

            _applicationDbContext.SaveChanges();
        }
    }
}
