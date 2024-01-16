using Microsoft.EntityFrameworkCore;
using Web_store.Data.Interfaces;
using Web_store.Data.Models;

namespace Web_store.Data.Repositories;

public class CategoryRepositiory : IItemsCategory
{
    private readonly ApplicationDbContext _applicationDbContext;

    public CategoryRepositiory(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public IEnumerable<Category> AllCategories => _applicationDbContext.Category;
}

public class ItemRepository : IAllItems
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ItemRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public IEnumerable<Item> Items => _applicationDbContext.Item.Include(c => c.Category);

    public IEnumerable<Item> GetFavItem => _applicationDbContext.Item.Where(p => p.IsFavourite).Include(c => c.Category);

    public Item GetObjectItem(int id)
    {
        return _applicationDbContext.Item.FirstOrDefault(p => p.Id == id);
    }
}

public class Repository
{
}

public interface IRepository
{
}

