using Microsoft.AspNetCore.Mvc;
using Web_store.Data.Interfaces;
using Web_store.ViewModels;

namespace Web_store.Controllers
{
    public class HomeController : Controller
    {
        public IItems Items;

        public HomeController(IItems items)
        {
            Items = items;
        }

        public ViewResult Index()
        {
            var homeItems = new HomeViewModels
            {
                FavauriteItems = Items.FavouriteItems
            };

            return View(homeItems);
        }
    }
}
