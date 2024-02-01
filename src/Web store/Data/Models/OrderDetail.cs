namespace Web_store.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public uint Price { get; set; }
        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
}
