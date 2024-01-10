using Web_store.Data.Interfaces;
using Web_store.Data.Models;

namespace Web_store.Data.Mocks;

public class MockCategory : IItemsCategory
{
    public IEnumerable<Category> AllCategories
    {
        get
        {
            return new List<Category>
            {
                new() { Name = "Мечи", Description = "Короткие, длинные, кривые, прямые, двуручные, одноручные..." },
                new() { Name = "Щиты", Description = "Круглые, треугольные, квадратные, прямоугольные, треугольные, овальные..." },
            };
        }
    }
}
