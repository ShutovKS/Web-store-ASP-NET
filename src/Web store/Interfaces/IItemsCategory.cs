using Web_store.Models;

namespace Web_store.Interfaces;

public interface IItemsCategory
{
    IEnumerable<Category> AllCategories { get; }
}
