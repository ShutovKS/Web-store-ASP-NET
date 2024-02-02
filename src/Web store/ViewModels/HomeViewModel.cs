using Web_store.Data.Models;

namespace Web_store.ViewModels;

public class HomeViewModel
{
    public IEnumerable<Item> FavauriteItems { get; set; }
}

