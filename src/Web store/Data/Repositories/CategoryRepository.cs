using Web_store.Data.Interfaces;
using Web_store.Data.Models;

namespace Web_store.Data.Repositories;

public class CategoryRepository : IItemsCategory
{
    private readonly ApplicationDbContext _applicationDbContext;

    public CategoryRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public IEnumerable<Category> AllCategories => _applicationDbContext.Category;
}
