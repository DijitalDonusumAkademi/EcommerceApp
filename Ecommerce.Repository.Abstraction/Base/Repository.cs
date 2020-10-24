using System.Collections.Generic;
using System.Linq;
using Ecommerce.Repository.Abstraction.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository.Abstraction.Base
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _db;

        public Repository(DbContext db)
        {
            _db = db;
        }

        DbSet<T> Table
        {
            get { return _db.Set<T>(); }
        }


        public virtual void Add(T entity)
        {
            Table.Add(entity);
            _db.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public virtual void Remove(T entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }

        public ICollection<T> GetAll()
        {
            return Table.ToList();
        }
    }
}