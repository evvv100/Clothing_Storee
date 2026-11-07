using Model;
using DataAccessLayer;

namespace Logic
{
    /// <summary>
    /// Класс бизнес-логики, управляющий товарами на складе: добавление, изменение, удаление, фильтрация по размеру и категории.
    /// </summary>
    public class Logic : ILogic
    {
        private readonly IClothingCommand _command;
        private readonly IClothingQuery _query;
        private readonly IClothingFilter _filter;
        /// <summary>
        /// Инициализирует новый экземпляр класса Logic с заданным репозиторием.
        /// </summary>
        /// <param name="repository">Экземпляр репозитория для работы с данными.</param>
        /// <exception cref="ArgumentNullException">Исключение генерируется, если переданный репозиторий равен null.</exception>
        public Logic(IClothingCommand command, IClothingQuery query, IClothingFilter filter)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
            _query = query ?? throw new ArgumentNullException(nameof(query));
            _filter = filter ?? throw new ArgumentNullException(nameof(filter));
        }

        /// <summary>
        /// Создает и добавляет новый товар на склад.
        /// </summary>
        /// <param name="name">Название вещи.</param>
        /// <param name="category">Категория одежды.</param>
        /// <param name="size">Размер одежды.</param>
        /// <param name="price">Цена товара.</param>
        public void AddClothing(string name, ClothingCategory category, ClothingSize size, int price)
        {
            _command.AddClothing(name, category, size, price);
        }
        /// <summary>
        /// Удаляет товар со склада по ID.
        /// </summary>
        /// <param name="id">Артикул удаляемого товара.</param>
        /// <exception cref="InvalidOperationException">Генерируется, если товар не найден на складе.</exception>
        public void RemoveClothing(int id)
        {
            _command.RemoveClothing(id);
        }
        /// <summary>
        /// Возвращает список всех товаров, хранящихся на складе.
        /// </summary>
        /// <returns>Список объектов Clothing.</returns>
        public List<Clothing> GetAll()
        {
            return _query.GetAll();
        }

        /// <summary>
        /// Возвращает одежду по Id
        /// </summary>
        /// <param name="id">Id товара, который нужен</param>
        /// <returns>Объект Clothing или null, если товар не найден.</returns>
        public Clothing GetClothingById(int id)
        {
            return _query.GetClothingById(id);
        }

        /// <summary>
        /// Изменяет данные товара на складе (артикул сохраняется).
        /// </summary>
        /// <param name="clothing">Товар с новыми данными. Артикул определяет, какой товар изменяется.</param>
        /// <exception cref="InvalidOperationException">Генерируется, если товар не найден на складе.</exception>
        public void ChangeClothing(Clothing clothing)
        {
            _command.ChangeClothing(clothing);
        }
        /// <summary>
        /// Возвращает список товаров указанного размера.
        /// </summary>
        /// <param name="source">Список товаров, который нужно отфильтровать.</param>
        /// <param name="size">Размер, по которому выполняется фильтрация.</param>
        /// <returns>Список товаров указанного размера.</returns>
        /// <exception cref="ArgumentNullException">Генерируется, если список равен null.</exception>
        public List<Clothing> FilterBySize(List<Clothing> source, ClothingSize size)
        {
            return _filter.FilterBySize(source, size);
        }

        /// <summary>
        /// Возвращает список товаров указанной категории.
        /// </summary>
        /// <param name="source">Список товаров, который нужно отфильтровать.</param>
        /// <param name="category">Категория, по которой выполняется фильтрация.</param>
        /// <returns>Список товаров указанной категории.</returns>
        /// <exception cref="ArgumentNullException">Если переданный список равен null.</exception>
        public List<Clothing> FilterByCategory(List<Clothing> source, ClothingCategory category)
        {
            return _filter.FilterByCategory(source, category);
        }
        /// <summary>
        /// Заполняет хранилище данных начальным тестовым набором одежды разного типа и размеров.
        /// </summary>
        public void FilledTable()
        {
            AddClothing("Белая футболка", ClothingCategory.TShirt, ClothingSize.M, 1500);
            AddClothing("Черная футболка", ClothingCategory.TShirt, ClothingSize.L, 1800);
            AddClothing("Синие джинсы", ClothingCategory.Jeans, ClothingSize.XL, 4500);
            AddClothing("Черные джинсы", ClothingCategory.Jeans, ClothingSize.S, 4200);
            AddClothing("Джинсовая куртка", ClothingCategory.Jacket, ClothingSize.M, 6500);
            AddClothing("Зимний пуховик", ClothingCategory.Jacket, ClothingSize.XL, 12000);
            AddClothing("Шорты белые", ClothingCategory.Shorts, ClothingSize.M, 350);
            AddClothing("Шорты с принтом", ClothingCategory.Shorts, ClothingSize.S, 400);
            AddClothing("Черное платье", ClothingCategory.Dress, ClothingSize.M, 5500);
            AddClothing("Летнее платье", ClothingCategory.Dress, ClothingSize.XS, 3800);
        }
    }
}
