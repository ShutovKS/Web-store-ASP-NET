using Web_store.Models;
using Web_store.Project_Files.Interfaces;

namespace Web_store.Project_Files.Mocks;

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
