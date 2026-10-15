namespace Model
{
    public class Clothing : IDomainObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ClothingCategory Category { get; set; }
        public ClothingSize Size { get; set; }
        public int Price { get; set; }
        public bool IsSold { get; set; }
        public Clothing()
        {

        }
        public Clothing(int id, string name, ClothingCategory category, ClothingSize size, int price)
        {
            Id = id;
            Name = name;
            Category = category;
            Size = size;
            Price = price;
            IsSold = false;
        }
    }
}
