using Web_store.Models;

namespace Web_store.Interfaces;

public interface IAllItems
{
    IEnumerable<Item> Items { get; }
    IEnumerable<Item> GetFavItem { get; }
    Item GetObjectItem(int id);
}
