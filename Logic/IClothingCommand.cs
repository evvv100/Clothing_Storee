using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Интерфейс для операций изменения данных склада (добавление, изменение и удаление).
    /// </summary>
    public interface IClothingCommand
    {
        /// <summary>
        /// Добавление товара на склад
        /// </summary>
        /// <param name="name">Название товара</param>
        /// <param name="category">Категория товара</param>
        /// <param name="size">Размер товара</param>
        /// <param name="price">Цена товара</param>
        void AddClothing(string name, ClothingCategory category, ClothingSize size, int price);
        /// <summary>
        /// Изменение товара
        /// </summary>
        /// <param name="clothing">Товар с новыми данными</param>
        void ChangeClothing(Clothing clothing);
        /// <summary>
        /// Удаление товара по id
        /// </summary>
        /// <param name="id">Артикул товара</param>
        void RemoveClothing(int id);
    }
}
