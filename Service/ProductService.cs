using Multipleİmage.Data;
using Multipleİmage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multipleİmage.Service
{
    public class ProductService : IRepository<Product>
    {
        private IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public void Delete(Product entity)
        {
            _repository.Delete(entity);
        }

        public Product GetById(int id)
        {
           return _repository.GetById(id);
        }

        public IEnumerable<Product> GetList()
        {
            return _repository.GetList();
        }

        public void Save(Product entity)
        {
            _repository.Save(entity);
        }

        public void Update(Product entity)
        {
            _repository.Update(entity);
        }
    }
}
