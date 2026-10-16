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
    /// Контекст базы данных Entity Framework Core для управления постоянным хранилищем приложения.
    /// </summary>
    public class StoreContext : DbContext
    {
        /// <summary>
        /// Набор данных для управления таблицей одежды в базе данных.
        /// </summary>
        public DbSet<Clothing> Clothes { get; set; }
        /// <summary>
        /// Инициализирует новый экземпляр контекста StoreContext и гарантирует существование структуры базы данных.
        /// </summary>
        public StoreContext() { Database.EnsureCreated(); }
        /// <summary>
        /// Настраивает конфигурацию подключения к провайдеру базы данных SQL Server.
        /// </summary>
        /// <param name="optionsBuilder">Построитель параметров конфигурации контекста.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSettings.ConnectionString);

        }
        /// <summary>
        /// Конфигурирует схему данных и автоматически регистрирует все доменные сущности, реализующие интерфейс IDomainObject.
        /// </summary>
        /// <param name="modelBuilder">Построитель моделей Entity Framework Core.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypes = typeof(IDomainObject).Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IDomainObject).IsAssignableFrom(t));

            foreach (Type type in entityTypes)
            {
                modelBuilder.Entity(type);
            }
        }
    }
}
