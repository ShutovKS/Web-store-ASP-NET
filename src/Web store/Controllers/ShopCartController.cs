using Microsoft.AspNetCore.Mvc;
using Web_store.Data.Interfaces;
using Web_store.Data.Models;
using Web_store.ViewModels;

namespace Web_store.Controllers;

public class ShopCartController : Controller
{
    public ShopCartController(IItems itemRepository, ShopCart shopCart)
    {
        _itemRepository = itemRepository;
        _shopCart = shopCart;
    }

    private readonly IItems _itemRepository;
    private readonly ShopCart _shopCart;

    public ViewResult Index()
    {
        var items = _shopCart.GetShopItems();
        _shopCart.ItemsInCart = items;

        var obj = new ShopCartViewModel
        {
            ShopCart = _shopCart
        };

        return View(obj);
    }

    public RedirectToActionResult AddToCart(int id)
    {
        var item = _itemRepository.Items.FirstOrDefault(item => item.Id == id);

        if (item != null)
        {
            _shopCart.AddToCart(item, 1);
        }

        return RedirectToAction("Index");
    }
}