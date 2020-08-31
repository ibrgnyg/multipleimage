using Microsoft.EntityFrameworkCore;
using Multipleİmage.Data;
using Multipleİmage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multipleİmage.Service
{
    public class Repository<T> : IRepository<T> where T: BaseModel
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbset;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }
        public void Delete(T entity)
        {
            _dbset.Remove(entity);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _dbset.Find(id);
        }

        public IEnumerable<T> GetList()
        {
            return _dbset.AsEnumerable();
        }

        public void Save(T entity)
        {
            _dbset.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
