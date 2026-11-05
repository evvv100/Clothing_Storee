using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Интерфейс для чтения и поиска данных товаров на складе.
    /// </summary>
    public interface IClothingQuery
    {
        /// <summary>
        /// Возвращает список всех товаров на складе.
        /// </summary>
        /// <returns>Список товаров со склада</returns>
        List<Clothing> GetAll();
        /// <summary>
        /// Возвращает товар по ID
        /// </summary>
        /// <param name="id">Артикул товара</param>
        /// <returns>Объект Clothing - товар</returns>
        Clothing GetClothingById(int id);
    }
}
