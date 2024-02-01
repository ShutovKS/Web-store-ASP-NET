using Microsoft.EntityFrameworkCore;
using Web_store.Data.Interfaces;
using Web_store.Data.Models;

namespace Web_store.Data.Repositories;

public class ItemsRepository : IItems
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ItemsRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public IEnumerable<Item> Items => _applicationDbContext.Item.Include(c => c.Category);

    public IEnumerable<Item> FavouriteItems => _applicationDbContext.Item.Where(p => p.IsFavourite).Include(c => c.Category);

    public Item GetObjectItem(int id)
    {
        return _applicationDbContext.Item.FirstOrDefault(p => p.Id == id);
    }
}
