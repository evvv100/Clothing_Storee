using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DataAccessLayer
{
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private StoreContext _context;
        public EntityRepository()
        {
            _context = new StoreContext();
        }
        public void Add(T item)
        {
            if (item == null) return;
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            T found = _context.Set<T>().Find(id);
            if (found == null) return;

            _context.Set<T>().Remove(found);
            _context.SaveChanges();
        }
        public List<T> ReadAll()
        {
            return _context.Set<T>().ToList();
        }
        public T ReadById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Update(T item)
        {
            if (item == null) return;

            // 1. Прикрепим объект к контексту, если он еще не там
            _context.Set<T>().Attach(item);

            // 2. Явно говорим EF6: "Этот объект изменен, сгенерируй для него SQL-запрос UPDATE"
            _context.Entry(item).State = EntityState.Modified;

            // 3. Сохраняем изменения в базу
            _context.SaveChanges();
        }
    }
}
