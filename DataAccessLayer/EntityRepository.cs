using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Обобщенный репозиторий Entity Framework Core для выполнения базовых CRUD-операций с доменными сущностями.
    /// </summary>
    /// <typeparam name="T">Тип доменного объекта, реализующий интерфейс <see cref="IDomainObject"/>.</typeparam>
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        /// <summary>
        /// Контекст базы данных для взаимодействия с постоянным хранилищем.
        /// </summary>
        private StoreContext _context;
        /// <summary>
        /// Инициализирует новый экземпляр класса EntityRepository{T} и создает контекст базы данных.
        /// </summary>
        public EntityRepository()
        {
            _context = new StoreContext();
        }
        /// <summary>
        /// Добавляет новый объект в базу данных и сохраняет изменения.
        /// </summary>
        /// <param name="item">Добавляемый объект сущности.</param>
        public void Add(T item)
        {
            if (item == null) return;
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }
        /// <summary>
        /// Удаляет объект из базы данных по его уникальному идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор удаляемого объекта.</param>
        public void Delete(int id)
        {
            T found = _context.Set<T>().Find(id);
            if (found == null) return;

            _context.Set<T>().Remove(found);
            _context.SaveChanges();
        }
        /// <summary>
        /// Возвращает список всех объектов данного типа из базы данных.
        /// </summary>
        /// <returns>Список всех сущностей типа <typeparamref name="T"/>.</returns>
        public List<T> ReadAll()
        {
            return _context.Set<T>().ToList();
        }
        /// <summary>
        /// Находит и возвращает объект по его уникальному идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор искомого объекта.</param>
        /// <returns>Найденный объект сущности или null, если объект не найден.</returns>
        public T ReadById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        /// <summary>
        /// Обновляет данные существующего объекта в базе данных, копируя текущие значения из переданного экземпляра.
        /// </summary>
        /// <param name="item">Объект сущности с обновленными данными.</param>
        public void Update(T item)
        {
            if (item == null) return;

            T? tracked = _context.Set<T>().Find(item.Id);
            if (tracked == null) return;

            _context.Entry(tracked).CurrentValues.SetValues(item);
            _context.SaveChanges();
        }
    }
}
