using Multipleİmage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multipleİmage.Service
{
    public class ProductPhotoService : IRepository<ProductPhoto>
    {
        private IRepository<ProductPhoto> _repository;
        public ProductPhotoService(IRepository<ProductPhoto> repository)
        {
            _repository = repository;
        }
        public void Delete(ProductPhoto entity)
        {
            _repository.Delete(entity);
        }

        public ProductPhoto GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<ProductPhoto> GetList()
        {
            
            return _repository.GetList();
        }

        public void Save(ProductPhoto entity)
        {
            _repository.Save(entity);
        }

        public void Update(ProductPhoto entity)
        {
            _repository.Update(entity);
        }
    }
}
