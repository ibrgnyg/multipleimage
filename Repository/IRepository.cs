using Multipleİmage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multipleİmage
{
    public interface IRepository<T>where T : BaseModel
    {
        IEnumerable<T> GetList();
        T GetById(int id);
        void Save(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
