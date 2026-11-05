using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Интерфейс для фильтрации одежды
    /// </summary>
    public interface IClothingFilter
    {
        /// <summary>
        /// Фильтрует одежду по размеру
        /// </summary>
        /// <param name="source">Список товаров со склада</param>
        /// <param name="size">Размер</param>
        /// <returns>Отфильтрованный список товаров</returns>
        List<Clothing> FilterBySize(List<Clothing> source, ClothingSize size);
        /// <summary>
        /// Фильтрует одежду по категории 
        /// </summary>
        /// <param name="source">Список товаров со склада</param>
        /// <param name="category">Категория</param>
        /// <returns>Отфильтрованный список товаров</returns>
        List<Clothing> FilterByCategory(List<Clothing> source, ClothingCategory category);
    }
}
