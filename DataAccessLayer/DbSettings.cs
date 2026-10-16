using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Предоставляет статические настройки и параметры конфигурации для подключения к базе данных.
    /// </summary>
    public static class DbSettings
    {
        /// <summary>
        /// Строка подключения к локальной базе данных SQL Server (LocalDB) для магазина одежды.
        /// </summary>
        public const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Clothing_Store;Integrated Security=True";
    }
}
