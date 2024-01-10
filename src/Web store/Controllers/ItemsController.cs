using Microsoft.AspNetCore.Mvc;
using Web_store.Data.Interfaces;
using Web_store.ViewModels;

namespace Web_store.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IAllItems _allItems;
        private readonly IItemsCategory _allCategories;

        public ItemsController(IAllItems iAllItems, IItemsCategory iItemsCat)
        {
            _allItems = iAllItems;
            _allCategories = iItemsCat;
        }

        public ViewResult List()
        {
            ItemsListViewModel itemsListViewModel = new()
            {
                AllItems = _allItems.Items,
                CurrentCategory = "..."
            };

            ViewBag.Title = "Страница с товарами";
            ViewBag.ItemsListViewModel = itemsListViewModel;

            return View();
        }
    }
}