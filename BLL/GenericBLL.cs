using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DuAn1_Nhom4.DAL;
using DuAn1_Nhom4.Models;

namespace DuAn1_Nhom4.BLL
{
    public class GenericBLL<T> where T : class
    {
        GenericDAL<T> dAL;
        public GenericBLL()
        {
            var context = new QuanLyKhoHangQuanAoContext();
            dAL = new GenericDAL<T>(context);
        }
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] inclues) => dAL.GetAll(inclues);
        public T? GetById(int id) => dAL.GetById(id);
        public void Add(T entity) => dAL.Add(entity);
        public void Update(T entity) => dAL.Update(entity);
        public void Delete(int id) => dAL.Delete(id);
        public bool Exists(Expression<Func<T, bool>> predicate) => dAL.Exists(predicate);
    }
}
