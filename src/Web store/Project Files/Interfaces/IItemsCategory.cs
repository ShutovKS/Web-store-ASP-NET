using Web_store.Models;

namespace Web_store.Project_Files.Interfaces;

public interface IItemsCategory
{
    IEnumerable<Category> AllCategories { get; }
}
