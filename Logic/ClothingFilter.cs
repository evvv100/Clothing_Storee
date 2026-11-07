using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Класс для фильтрации коллекций одежды по заданным критериям (размер, категория).
    /// Реализует разделенный интерфейс <see cref="IClothingFilter"/>.
    /// </summary>
    public class ClothingFilter : IClothingFilter
    {
        /// <summary>
        /// Фильтрует исходный список одежды, оставляя только товары указанного размера.
        /// </summary>
        /// <param name="source">Исходный список товаров для фильтрации.</param>
        /// <param name="size">Целевой размер одежды.</param>
        /// <returns>Новый список товаров, отфильтрованный по размеру.</returns>
        /// <exception cref="ArgumentNullException">Генерируется, если переданный исходный список равен null.</exception>
        public List<Clothing> FilterBySize(List<Clothing> source, ClothingSize size)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.Where(c => c.Size == size).ToList();
        }
        /// <summary>
        /// Фильтрует исходный список одежды, оставляя только товары указанной категории.
        /// </summary>
        /// <param name="source">Исходный список товаров для фильтрации.</param>
        /// <param name="category">Целевая категория одежды.</param>
        /// <returns>Новый список товаров, отфильтрованный по категории.</returns>
        /// <exception cref="ArgumentNullException">Генерируется, если переданный исходный список равен null.</exception>
        public List<Clothing> FilterByCategory(List<Clothing> source, ClothingCategory category)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.Where(c => c.Category == category).ToList();
        }
    }
}
