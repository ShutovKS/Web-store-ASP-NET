namespace Web_store.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Item { get; set; }
}
