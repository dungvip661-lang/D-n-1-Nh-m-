using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DuAn1_Nhom4.Models;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace DuAn1_Nhom4.DAL
{
    public class GenericDAL<T>(QuanLyKhoHangQuanAoContext context) where T : class
    {
        QuanLyKhoHangQuanAoContext _context = context;
        DbSet<T> _dbSet = context.Set<T>();
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] inclues)
        {
            IQueryable<T> query = _dbSet;
            if (inclues != null && inclues.Length > 0)
            {
                foreach (var inclue in inclues)
                {
                    query = query.Include(inclue);
                }
            }
            return query.ToList();
        }
        public IEnumerable<T> GetAllAccount(params Expression<Func<T, object>>[] inclues)
        {
            IQueryable<T> query = _dbSet;
            if (inclues != null && inclues.Length > 0)
            {
                foreach (var inclue in inclues)
                {
                    query = query.Include(inclue);
                }
            }
            return query.AsNoTracking().ToList();
        }
        public T? GetById(int id) => _dbSet.Find(id);
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();

        }
        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }
        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }
    }
}

