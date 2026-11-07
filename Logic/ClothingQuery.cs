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
    /// Класс для выполнения запросов чтения и поиска данных о товарах на складе.
    /// Реализует разделенный интерфейс <see cref="IClothingQuery"/>.
    /// </summary>
    public class ClothingQuery : IClothingQuery
    {
        /// <summary>
        /// Репозиторий для доступа к постоянному хранилищу одежды.
        /// </summary>
        private readonly IRepository<Clothing> _repository;
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ClothingQuery"/> с заданным репозиторием.
        /// </summary>
        /// <param name="repository">Экземпляр репозитория для работы с данными.</param>
        /// <exception cref="ArgumentNullException">Генерируется, если переданный репозиторий равен null.</exception>
        public ClothingQuery(IRepository<Clothing> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        /// <summary>
        /// Возвращает список всех товаров, хранящихся на складе.
        /// </summary>
        /// <returns>Список объектов <see cref="Clothing"/>.</returns>
        public List<Clothing> GetAll()
        {
            return _repository.ReadAll();
        }
        /// <summary>
        /// Возвращает данные о товаре по его уникальному идентификатору (ID).
        /// </summary>
        /// <param name="id">Идентификатор (артикул) искомого товара.</param>
        /// <returns>Объект <see cref="Clothing"/> или null, если товар не найден.</returns>
        public Clothing GetClothingById(int id)
        {
            return _repository.ReadById(id);
        }
    }
}
