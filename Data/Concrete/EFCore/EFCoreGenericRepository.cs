using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EFCore
{
    public class EFCoreGenericRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class
    where TContext : DbContext, new()
    {
        public void Create(TEntity entity)
        {
            using (var db = new TContext())
            {
                db.Set<TEntity>().Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var db = new TContext())
            {
                db.Set<TEntity>().Remove(entity);
                db.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            using (var db = new TContext())
            {
                return db.Set<TEntity>().ToList();
            }
        }

        public TEntity GetById(int id)
        {
            using (var db = new TContext())
            {
                return db.Set<TEntity>().Find(id);
            }
        }

        public void Update(TEntity entity)
        {
            using (var db = new TContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}