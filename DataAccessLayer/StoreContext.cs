using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DataAccessLayer
{
    public class StoreContext : DbContext
    {
        public DbSet<Clothing> Clothes { get; set; }

        // Подключаемся к LocalDB и создаем локальный файл clothing_store.mdf в папке проекта
        public StoreContext() { Database.EnsureCreated(); }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Clothing_Store;Integrated Security=True");

        }
    }
}
