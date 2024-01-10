using Web_store.Data.Models;

namespace Web_store.Data.Interfaces;

public interface IItemsCategory
{
    IEnumerable<Category> AllCategories { get; }
}
