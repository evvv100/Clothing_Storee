using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// Представляет сущность одежды.
    /// </summary>
    [Table("Clothes")]
    public class Clothing : IDomainObject
    {
        /// <summary>
        /// Уникальный идентификатор товара.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название вещи.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Категория товара.
        /// </summary>
        public ClothingCategory Category { get; set; }
        /// <summary>
        /// Размер одежды.
        /// </summary>
        public ClothingSize Size { get; set; }
        /// <summary>
        /// Цена товара.
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Продан ли товар. True - продан, false - в наличии.
        /// </summary>
        public bool IsSold { get; set; }
        /// <summary>
        /// Инициализирует новый экземпляр класса Clothing без параметров, необходимый для работы ORM.
        /// </summary>
        public Clothing()
        {

        }
        /// <summary>
        /// Инициализирует новый экземпляр класса Clothing с заданными параметрами.
        /// </summary>
        /// <param name="id">Уникальный идентификатор товара.</param>
        /// <param name="name">Название вещи.</param>
        /// <param name="category">Категория одежды.</param>
        /// <param name="size">Размер одежды.</param>
        /// <param name="price">Стоимость товара.</param>
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
