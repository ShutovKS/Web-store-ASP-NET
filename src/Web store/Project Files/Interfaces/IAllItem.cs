using Web_store.Models;

namespace Web_store.Project_Files.Interfaces;

public interface IAllItem
{
    IEnumerable<Item> Item { get; }
    IEnumerable<Item> GetFavItem { get; }
    Item GetObjectItem(int id);
}
