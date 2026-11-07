using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Класс для выполнения мутирующих операций и команд изменения данных одежды на складе (добавление, изменение, удаление).
    /// Реализует разделенный интерфейс <see cref="IClothingCommand"/>.
    /// </summary>
    public class ClothingCommand : IClothingCommand
    {
        /// <summary>
        /// Репозиторий для доступа к данным и постоянному хранилищу одежды.
        /// </summary>
        private readonly IRepository<Clothing> _repository;
        public ClothingCommand(IRepository<Clothing> repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            _repository = repository;
        }
        /// <summary>
        /// Добавление товара на склад
        /// </summary>
        /// <param name="name">Название товара</param>
        /// <param name="category">Категория товара</param>
        /// <param name="size">Размер товара</param>
        /// <param name="price">Цена товара</param>
        public void AddClothing(string name, ClothingCategory category, ClothingSize size, int price)
        {
            var clothing = new Clothing(0, name, category, size, price);
            _repository.Add(clothing);
        }
        /// <summary>
        /// Изменение товара
        /// </summary>
        /// <param name="clothing">Товар с новыми данными</param>
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
        /// Удаление товара по id
        /// </summary>
        /// <param name="id">Артикул товара</param>
        public void RemoveClothing(int id)
        {
            Clothing existing = _repository.ReadById(id);
            if (existing == null)
            {
                throw new InvalidOperationException("Товар не найден в каталоге.");
            }
            _repository.Delete(id);
        }
    }
}
