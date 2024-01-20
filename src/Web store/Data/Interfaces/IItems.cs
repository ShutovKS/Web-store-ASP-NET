using Web_store.Data.Models;

namespace Web_store.Data.Interfaces;

public interface IItems
{
    IEnumerable<Item> Items { get; }
    IEnumerable<Item> GetFavItem { get; }
    Item GetObjectItem(int id);
}
