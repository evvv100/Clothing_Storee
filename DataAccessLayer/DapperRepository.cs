using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using Dapper;
using Model;

namespace DataAccessLayer
{
    public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\clothing_store.mdf;Integrated Security=True";
        /// <summary>
        /// Добавляет товар. Id выдает БД (IDENTITY) и записывается обратно в item.Id
        /// </summary>
        public void Add(T item)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Clothes (Name, Category, Size, Price, IsSold) " +
                              "VALUES (@Name, @Category, @Size, @Price, @IsSold)";
                db.Execute(sql, item);
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute("DELETE FROM Clothes WHERE Id = @id", new { id });
            }
        }
        public List<T> ReadAll()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Clothes";
                return db.Query<T>(sql).ToList();
            }
        }
        public T ReadById(int id)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Clothes WHERE Id = @Id";
                return db.QueryFirstOrDefault<T>(sql, new { Id = id });
            }
        }
        public void Update(T item)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql =
                     "UPDATE Clothes SET Name = @Name, Category = @Category, Size = @Size, " +
                     "Price = @Price, IsSold = @IsSold WHERE Id = @Id";
                db.Execute(sql, item);
            }
        }
    }
}
