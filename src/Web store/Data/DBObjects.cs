using Web_store.Data.Models;

namespace Web_store.Data;

public static class DBObjects
{
    public static void Initialize(ApplicationDbContext applicationDbContext)
    {
        if (!applicationDbContext.Category.Any())
        {
            applicationDbContext.Category.AddRange(Categories.Select(c => c.Value));
        }

        if (!applicationDbContext.Item.Any())
        {
            applicationDbContext.Item.AddRange(Items.Select(c => c.Value));
        }

        applicationDbContext.SaveChanges();
    }

    private static Dictionary<string, Category> _categories;
    public static Dictionary<string, Category> Categories
    {
        get
        {
            if (_categories == null)
            {
                var list = new Category[]
                {
                    new() { Name = "Мечи", Description = "Короткие, длинные, кривые, прямые, двуручные, одноручные..." },
                    new() { Name = "Щиты", Description = "Круглые, треугольные, квадратные, прямоугольные, треугольные, овальные..." },
                };

                _categories = [];

                foreach (var item in list)
                {
                    _categories.Add(item.Name, item);
                }
            }

            return _categories;
        }
    }

    private static Dictionary<string, Item> _items;
    public static Dictionary<string, Item> Items
    {
        get
        {
            if (_items == null)
            {
                var list = new Item[]
                {
                    new()
        {
            Name = "Меч",
            ShortDescription = "Короткий меч",
            LongDescription = "Короткий меч, который можно использовать одной рукой",
            Image = "https://i.pinimg.com/originals/95/dd/18/95dd1863a5c1058f979519c9de996378.jpg",
            Price = 1000,
            IsFavourite = true,
            Available = true,
            Category = Categories["Мечи"]
        },
        new()
        {
            Name = "Щит",
            ShortDescription = "Круглый щит",
            LongDescription = "Круглый щит, который можно использовать одной рукой",
            Image = "https://superwalls.top/uploads/posts/2022-05/1653107827_16-gamerwall-pro-p-kruglii-shchit-fentezi-oboi-krasivo-17.jpg",
            Price = 500,
            IsFavourite = true,
            Available = true,
            Category = Categories["Щиты"]
        },
        new()
        {
            Name = "Меч",
            ShortDescription = "Длинный меч",
            LongDescription = "Длинный меч, который можно использовать одной рукой",
            Image = "http://cdn1.bigcommerce.com/server4100/dd172/products/1693/images/8492/44_Kirigaya_Kazuto_Kirito_black_Elucidator_Cosplay_sword__39969.1372106161.1000.675.jpg",
            Price = 2000,
            IsFavourite = true,
            Available = true,
            Category = Categories["Мечи"]
        },
        new()
        {
            Name = "Щит",
            ShortDescription = "Прямоугольный щит",
            LongDescription = "Прямоугольный щит, который можно использовать одной рукой",
            Image = "https://i.pinimg.com/originals/a9/2f/a8/a92fa88e9def5d3b347526341317d292.jpg",
            Price = 500,
            IsFavourite = true,
            Available = false,
            Category = Categories["Щиты"]
        },
                };

                _items = [];

                foreach (var item in list)
                {
                    _items.Add(item.ShortDescription, item);
                }
            }

            return _items;
        }
    }

}

