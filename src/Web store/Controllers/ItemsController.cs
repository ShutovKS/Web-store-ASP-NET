using Microsoft.AspNetCore.Mvc;
using Web_store.Data.Interfaces;
using Web_store.ViewModels;

namespace Web_store.Controllers;
public class ItemsController : Controller
{
    private readonly IItems _allItems;
    private readonly IItemsCategory _allCategories;

    public ItemsController(IItems iAllItems, IItemsCategory iItemsCat)
    {
        _allItems = iAllItems;
        _allCategories = iItemsCat;
    }

    public ViewResult List()
    {
        var obj = new ItemsListViewModel()
        {
            AllItems = _allItems.Items,
            CurrentCategory = "..."
        };

        ViewBag.Title = "Страница с товарами";

        return View(obj);
    }
}
