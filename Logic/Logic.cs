using Model;
using DataAccessLayer;

namespace Logic
{
    /// <summary>
    /// Класс бизнес-логики, управляющий товарами на складе: добавление, изменение, удаление, фильтрация по размеру и категории.
    /// </summary>
    public class Logic : ILogic
    {
        /// <summary>
        /// Репозиторий для доступа к данным и постоянному хранилищу одежды.
        /// </summary>
        private readonly IRepository<Clothing> _repository;
        /// <summary>
        /// Инициализирует новый экземпляр класса Logic с заданным репозиторием.
        /// </summary>
        /// <param name="repository">Экземпляр репозитория для работы с данными.</param>
        /// <exception cref="ArgumentNullException">Исключение генерируется, если переданный репозиторий равен null.</exception>
        public Logic(IRepository<Clothing> repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            _repository = repository;
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
            var clothing = new Clothing(0, name, category, size, price);
            _repository.Add(clothing);
        }
        /// <summary>
        /// Удаляет товар со склада по ID.
        /// </summary>
        /// <param name="id">Артикул удаляемого товара.</param>
        /// <exception cref="InvalidOperationException">Генерируется, если товар не найден на складе.</exception>
        public void RemoveClothing(int id)
        {
            Clothing existing = _repository.ReadById(id);
            if (existing == null)
            {
                throw new InvalidOperationException("Товар не найден в каталоге.");
            }
            _repository.Delete(id);
        }
        /// <summary>
        /// Возвращает список всех товаров, хранящихся на складе.
        /// </summary>
        /// <returns>Список объектов Clothing.</returns>
        public List<Clothing> GetAll()
        {
            return _repository.ReadAll();
        }

        /// <summary>
        /// Возвращает одежду по Id
        /// </summary>
        /// <param name="id">Id товара, который нужен</param>
        /// <returns>Объект Clothing или null, если товар не найден.</returns>
        public Clothing GetClothingById(int id)
        {
            return _repository.ReadById(id);
        }

        /// <summary>
        /// Изменяет данные товара на складе (артикул сохраняется).
        /// </summary>
        /// <param name="clothing">Товар с новыми данными. Артикул определяет, какой товар изменяется.</param>
        /// <exception cref="InvalidOperationException">Генерируется, если товар не найден на складе.</exception>
        public void ChangeClothing(Clothing clothing)
        {
            Clothing existing = _repository.ReadById(clothing.Id);
            if (existing == null)
            {
                throw new InvalidOperationException("Товар не найден на складе.");
            }
            existing.Name = clothing.Name.Trim();
            existing.Category = clothing.Category;
            existing.Size = clothing.Size;
            existing.Price = clothing.Price;
            _repository.Update(existing);
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
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return source.Where(c => c.Size == size).ToList();
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
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return source.Where(c => c.Category == category).ToList();
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
