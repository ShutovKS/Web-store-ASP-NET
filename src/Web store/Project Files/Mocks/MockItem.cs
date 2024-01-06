using Web_store.Models;
using Web_store.Project_Files.Interfaces;

namespace Web_store.Project_Files.Mocks;

public class MockItem : IAllItem
{
    private readonly IItemsCategory _categoryItem = new MockCategory();

    public IEnumerable<Item> Item => new List<Item>
    {
        new()
        {
            Name = "Меч",
            ShortDescription = "Короткий меч",
            LongDescription = "Короткий меч, который можно использовать одной рукой",
            Image = "https://i.pinimg.com/originals/95/dd/18/95dd1863a5c1058f979519c9de996378.jpg",
            Price = 1000,
            IsFavorite = true,
            Available = true,
            Category = _categoryItem.AllCategories.First()
        },
        new()
        {
            Name = "Щит",
            ShortDescription = "Круглый щит",
            LongDescription = "Круглый щит, который можно использовать одной рукой",
            Image = "https://superwalls.top/uploads/posts/2022-05/1653107827_16-gamerwall-pro-p-kruglii-shchit-fentezi-oboi-krasivo-17.jpg",
            Price = 500,
            IsFavorite = true,
            Available = true,
            Category = _categoryItem.AllCategories.Last()
        },
        new()
        {
            Name = "Меч",
            ShortDescription = "Длинный меч",
            LongDescription = "Длинный меч, который можно использовать одной рукой",
            Image = "http://cdn1.bigcommerce.com/server4100/dd172/products/1693/images/8492/44_Kirigaya_Kazuto_Kirito_black_Elucidator_Cosplay_sword__39969.1372106161.1000.675.jpg",
            Price = 2000,
            IsFavorite = true,
            Available = true,
            Category = _categoryItem.AllCategories.First()
        },
        new()
        {
            Name = "Щит",
            ShortDescription = "Прямоугольный щит",
            LongDescription = "Прямоугольный щит, который можно использовать одной рукой",
            Image = "https://i.pinimg.com/originals/a9/2f/a8/a92fa88e9def5d3b347526341317d292.jpg",
            Price = 500,
            IsFavorite = true,
            Available = false,
            Category = _categoryItem.AllCategories.First()
        },
    };

    public IEnumerable<Item> GetFavItem
    {
        get
        {
            return Item.Where(p => p.IsFavorite).ToList();
        }

    }


    public Item GetObjectItem(int id)
    {
        return Item.FirstOrDefault(p => p.Id == id);
    }
}
