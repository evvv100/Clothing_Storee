using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Реализует базовые CRUD-операции (создание, чтение, обновление, удаление).
    /// </summary>
    /// <typeparam name="T">Тип сущности, реализующий интерфейс IDomainObject.</typeparam>
    public interface IRepository<T> where T : IDomainObject
    {
        /// <summary>
        /// Добавляет новую сущность в базу данных.
        /// </summary>
        /// <param name="item">Объект сущности для добавления.</param>
        void Add(T item);

        /// <summary>
        /// Удаляет сущность из базы данных по её уникальному идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор (Id) удаляемой сущности.</param>
        void Delete(int id);

        /// <summary>
        /// Возвращает список всех сущностей, хранящихся в соответствующей таблице базы данных.
        /// </summary>
        /// <returns>Список всех объектов типа <typeparamref name="T"/>.</returns>
        List<T> ReadAll();

        /// <summary>
        /// Находит и возвращает конкретную сущность по её уникальному идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор (Id) искомой сущности.</param>
        /// <returns>Найденный объект типа <typeparamref name="T"/> или null, если объект не найден.</returns>
        T ReadById(int id);

        /// <summary>
        /// Обновляет данные существующей сущности в базе данных.
        /// </summary>
        /// <param name="item">Объект сущности с обновленными данными.</param>
        void Update(T item);
    }
}
