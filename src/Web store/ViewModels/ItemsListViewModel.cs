using Web_store.Data.Models;

namespace Web_store.ViewModels
{
    public class ItemsListViewModel
    {
        public IEnumerable<Item> AllItems { get; set; }
        public string CurrentCategory { get; set; }
    }
}
