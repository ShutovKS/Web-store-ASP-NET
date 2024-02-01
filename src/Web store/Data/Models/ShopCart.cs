using Microsoft.EntityFrameworkCore;

namespace Web_store.Data.Models;

public class ShopCart
{
    public ShopCart(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public string Id { get; set; }
    public List<ItemInCart> ItemsInCart { get; set; }
    public double TotalPrice { get; set; }

    private readonly ApplicationDbContext _applicationDbContext;

    public static ShopCart GetCart(IServiceProvider service)
    {
        var session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        var context = service.GetService<ApplicationDbContext>();
        var cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

        session.SetString("CartId", cartId);

        return new ShopCart(context) { Id = cartId };
    }

    public void AddToCart(Item item, int amount)
    {
        _applicationDbContext.ItemInCart.Add(
            new ItemInCart
            {
                ShopCartId = Id,
                Item = item,
                Price = item.Price * amount,
                Amount = amount,
            });

        _applicationDbContext.SaveChanges();

        //var shopItem = _applicationDbContext.ItemInCart.SingleOrDefault(s => s.Item.Id == item.Id && s.ShopCartId == Id);

        //if (shopItem == null)
        //{
        //    shopItem = new ItemInCart
        //    {
        //        ShopCartId = Id,
        //        Item = item,
        //        Amount = amount,
        //        Price = item.Price * amount,
        //    };

        //    _applicationDbContext.ItemInCart.Add(shopItem);
        //}
        //else
        //{
        //    shopItem.Amount += amount;
        //    shopItem.Price += item.Price * amount;
        //}

        //_applicationDbContext.SaveChanges();
    }
    public List<ItemInCart> GetShopItems()
    {
        return _applicationDbContext.ItemInCart.Where(c => c.ShopCartId == Id).Include(s => s.Item).ToList();
    }
}