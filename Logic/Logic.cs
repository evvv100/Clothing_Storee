using Model;
using DataAccessLayer;

namespace Logic
{
    public class Logic
    {
        private readonly IRepository<Clothing> _repository;
        public Logic(IRepository<Clothing> repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            _repository = repository;
        }

        /// <summary>
        /// Добавляет одежду в каталог
        /// </summary>
        /// <param name="clothing">Одежда, которую надо добавить</param>
        public void AddClothing(string name, ClothingCategory category, ClothingSize size, int price)
        {
            var clothing = new Clothing(0, name, category, size, price);
            _repository.Add(clothing);
        }
        /// <summary>
        /// Удаляет одежду из каталога по Id
        /// </summary>
        /// <param name="id">Id одежды, которую нужно удалить из каталога</param>
        public void RemoveClothing(int id)
        {
            Clothing existing = _repository.ReadById(id);
            if (existing == null || existing.IsSold)
            {
                throw new InvalidOperationException("Товар не найден в каталоге.");
            }
            _repository.Delete(id);
        }
        /// <summary>
        /// Возвращает список - каталог товаров в логике
        /// </summary>
        /// <param name="clothing">Список товаров, который хранится в экзмепляре класса Logic</param>
        public List<Clothing> GetCatalog()
        {
            return _repository.ReadAll().Where(c => !c.IsSold).ToList();
        }
        /// <summary>
        /// Возвращает купленные товары (история покупок)
        /// </summary>
        public List<Clothing> GetPurchased()
        {
            return _repository.ReadAll().Where(c => c.IsSold).ToList();
        }

        /// <summary>
        /// Возвращает одежду по Id
        /// </summary>
        /// <param name="id">Id товара, который нужен</param>
        /// <returns>Возвращает объект Clothing по Id</returns>
        public Clothing GetClothingById(int id)
        {
            return _repository.ReadById(id);
        }
        /// <summary>
        /// Изменяет конкретный товар по Id (Id сохраняется)
        /// </summary>
        /// <param name="clothing">Объект Clothing, который нужно изменить в каталоге</param>
        public void ChangeClothing(Clothing clothing)
        {
            Clothing existing = _repository.ReadById(clothing.Id);
            if (existing == null || existing.IsSold)
            {
                throw new InvalidOperationException("Товар не найден в каталоге.");
            }
            existing.Name = clothing.Name.Trim();
            existing.Category = clothing.Category;
            existing.Size = clothing.Size;
            existing.Price = clothing.Price;
            _repository.Update(existing);
        }
        /// <summary>
        /// Оформляет покупку: помечает товары купленными. Если хоть один товар уже недоступен - ничего не покупается
        /// </summary>
        /// <param name="items">Товары из корзины</param>
        public void Buy(List<Clothing> basket)
        {
            if (basket == null || basket.Count == 0)
            {
                throw new InvalidOperationException("Корзина пуста.");
            }

            foreach (Clothing item in basket)
            {
                Clothing current = _repository.ReadById(item.Id);

                if (current == null || current.IsSold)
                {
                    throw new InvalidOperationException($"Товар «{item.Name}» уже недоступен.");
                }
            }

            foreach (Clothing item in basket)
            {
                Clothing current = _repository.ReadById(item.Id);
                current.IsSold = true;
                _repository.Update(current);
            }
        }

        /// <summary>
        /// Возвращает купленный товар обратно в магазин
        /// </summary>
        /// <param name="id">Id купленного товара</param>
        public void ReturnToStore(int id)
        {
            Clothing item = _repository.ReadById(id);
            if (item == null || !item.IsSold)
            {
                throw new InvalidOperationException("Такого купленного товара нет.");
            }
            item.IsSold = false;
            _repository.Update(item);
        }

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
