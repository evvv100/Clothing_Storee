using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Главный объединенный интерфейс бизнес-логики приложения.
    /// Объединяет контракты команд <see cref="IClothingCommand"/>, запросов <see cref="IClothingQuery"/> и фильтрации <see cref="IClothingFilter"/>, выступая единой точкой доступа.
    /// </summary>
    public interface ILogic : IClothingCommand, IClothingQuery, IClothingFilter
    {
        /// <summary>
        /// Заполняет хранилище данных начальным тестовым набором одежды.
        /// </summary>
        void FilledTable();
    }
}
