namespace Web_store.Data.Models;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public string Image { get; set; }
    public ushort Price { get; set; }
    public bool IsFavorite { get; set; }
    public bool Available { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}
