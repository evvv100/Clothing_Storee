using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace DataAccessLayer
{
    /// <summary>
    /// Обобщенный репозиторий на базе микро-ORM Dapper для выполнения высокопроизводительных CRUD-операций с автоматической генерацией SQL-запросов через рефлексию.
    /// </summary>
    /// <typeparam name="T">Тип доменного объекта, реализующий интерфейс IDomainObject.</typeparam>
    public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        /// <summary>
        /// Имя таблицы в базе данных, вычисленное на основе атрибута TableAttribute или имени класса <typeparamref name="T"/>.
        /// </summary>
        private static readonly string Table =
            typeof(T).GetCustomAttribute<TableAttribute>()?.Name ?? typeof(T).Name;
        /// <summary>
        /// Массив имен свойств (колонок), которые участвуют в операциях вставки и обновления (исключая Id).
        /// </summary>
        private static readonly string[] Columns = typeof(T)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanRead && p.CanWrite && p.Name != "Id" && IsSimple(p.PropertyType))
            .Select(p => p.Name)
            .ToArray();
        /// <summary>
        /// SQL-запрос для вставки записи в базу данных с последующим возвратом сгенерированного Id.
        /// </summary>
        private static readonly string InsertSql =
            $"INSERT INTO [{Table}] ({string.Join(", ", Columns.Select(c => $"[{c}]"))}) " +
            $"VALUES ({string.Join(", ", Columns.Select(c => "@" + c))}); " +
            "SELECT CAST(SCOPE_IDENTITY() AS int);";
        /// <summary>
        /// SQL-запрос для обновления всех изменяемых свойств записи по её уникальному идентификатору.
        /// </summary>
        private static readonly string UpdateSql =
            $"UPDATE [{Table}] SET {string.Join(", ", Columns.Select(c => $"[{c}] = @{c}"))} WHERE [Id] = @Id";
        /// <summary>
        /// SQL-запрос для выборки всех записей из таблицы.
        /// </summary>
        private static readonly string SelectAllSql = $"SELECT * FROM [{Table}]";
        /// <summary>
        /// SQL-запрос для выборки одной записи по её уникальному идентификатору.
        /// </summary>
        private static readonly string SelectByIdSql = $"SELECT * FROM [{Table}] WHERE [Id] = @Id";
        /// <summary>
        /// SQL-запрос для удаления записи по её уникальному идентификатору.
        /// </summary>
        private static readonly string DeleteSql = $"DELETE FROM [{Table}] WHERE [Id] = @Id";
        /// <summary>
        /// Строка подключения к используемой базе данных.
        /// </summary>
        private readonly string _connectionString;
        /// <summary>
        /// Инициализирует новый экземпляр класса DapperRepository{T} со строкой подключения по умолчанию.
        /// </summary>
        public DapperRepository() : this(DbSettings.ConnectionString) { }
        /// <summary>
        /// Инициализирует новый экземпляр класса DapperRepository{T} с переданной строкой подключения.
        /// </summary>
        /// <param name="connectionString">Строка подключения к базе данных.</param>
        public DapperRepository(string connectionString) { _connectionString = connectionString; }
        /// <summary>
        /// Проверяет, является ли тип данных простым встроенным типом C# (значимым типом или строкой) для фильтрации колонок.
        /// </summary>
        /// <param name="type">Проверяемый тип данных.</param>
        /// <returns>Значение true, если тип относится к простым, иначе — false.</returns>
        private static bool IsSimple(Type type)
        {
            type = Nullable.GetUnderlyingType(type) ?? type;
            return type.IsValueType || type == typeof(string);
        }
        /// <summary>
        /// Добавляет сущность в базу данных. Сгенерированный базой данных идентификатор автоматически записывается в свойство Id переданного объекта.
        /// </summary>
        /// <param name="item">Добавляемый объект сущности.</param>
        public void Add(T item)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                item.Id = db.ExecuteScalar<int>(InsertSql, item);
            }
        }
        /// <summary>
        /// Удаляет сущность из базы данных по её уникальному идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор (Id) удаляемой сущности.</param>
        public void Delete(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Execute(DeleteSql, new { Id = id });
            }
        }
        /// <summary>
        /// Возвращает список всех сущностей, хранящихся в соответствующей таблице базы данных.
        /// </summary>
        /// <returns>Список всех объектов типа <typeparamref name="T"/>.</returns>
        public List<T> ReadAll()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return db.Query<T>(SelectAllSql).ToList();
            }
        }
        /// <summary>
        /// Находит и возвращает конкретную сущность по её уникальному идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор (Id) искомой сущности.</param>
        /// <returns>Найденный объект типа <typeparamref name="T"/> или null, если объект не найден.</returns>
        public T ReadById(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return db.QueryFirstOrDefault<T>(SelectByIdSql, new { Id = id })!;
            }
        }
        /// <summary>
        /// Обновляет данные существующей сущности в базе данных.
        /// </summary>
        /// <param name="item">Объект сущности с обновленными данными.</param>
        public void Update(T item)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Execute(UpdateSql, item);
            }
        }
    }
}
