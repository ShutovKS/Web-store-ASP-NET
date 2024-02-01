namespace Web_store.Data.Models;

public class ItemInCart
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }
    public string ShopCartId { get; set; }
}
