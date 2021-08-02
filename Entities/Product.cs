namespace Entities
{
    public class Product : BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int MarkId { get; set; }
        public Mark Mark { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Price{ get; set; }
        public string Image { get; set; }
    }
}
