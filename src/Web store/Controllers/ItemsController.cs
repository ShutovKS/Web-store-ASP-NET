using Microsoft.AspNetCore.Mvc;
using Web_store.Data.Interfaces;
using Web_store.Data.Models;
using Web_store.ViewModels;

namespace Web_store.Controllers;
public class ItemsController : Controller
{
    public ItemsController(IItems iAllItems, IItemsCategory iItemsCat)
    {
        _allItems = iAllItems;
        _allCategories = iItemsCat;
    }


    private readonly IItems _allItems;
    private readonly IItemsCategory _allCategories;

    [Route("Items/List")]
    [Route("Items/List/{category}")]
    public ViewResult List(string category)
    {
        IEnumerable<Item> items;
        string curentCategory;

        if (string.IsNullOrEmpty(category))
        {
            curentCategory = string.Empty;
            items = _allItems.Items.OrderBy(item => item.Id);
        }
        else
        {
            curentCategory = category;
            items = _allItems.Items.Where(item => item.Category.Name == category).OrderBy(item => item.Id);
        }

        var obj = new ItemsListViewModel()
        {
            AllItems = items,
            CurrentCategory = "..."
        };

        ViewBag.Title = "Страница с товарами";

        return View(obj);
    }
}
