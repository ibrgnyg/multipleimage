using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multipleİmage.Data;
using Multipleİmage.Models;
using Multipleİmage.Service;

namespace Multipleİmage.Controllers
{
    public class ProductController : Controller
    {
      
        private IRepository<Product> _repository;
        private IRepository<ProductPhoto>  _repositoryphoto;
        private IHostingEnvironment _environment;
        private readonly ApplicationDbContext _context;
        public ProductController(IRepository<Product> repository,IHostingEnvironment hosting ,IRepository<ProductPhoto> repositoryp,ApplicationDbContext context)
        {
            _context = context;
            _repositoryphoto = repositoryp;
            _environment = hosting;
            _repository = repository;
        }


        public IActionResult Index()
        {
           
            var result = _context.products
            .Include(c => c.ProductPhotos).ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product ,List<IFormFile> files)
        {

            if (files != null)
            {
                var filepath = Path.Combine(_environment.WebRootPath, "mimg");
                foreach (var item in files)
                {
                    if (item.Length > 0)
                    {
                        var file = Path.Combine(filepath, item.FileName);

                        using (var getfile = new FileStream(file, FileMode.Create))
                        {
                            item.CopyTo(getfile);

                        }
                        product.ProductPhotos.Add(new ProductPhoto { AllPhotos = item.FileName });
                    }

                }

            }
            product.CreateDate = DateTime.Now;
            _repository.Save(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            _context.productPhotos.ToList();
            return View(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Product product,List<IFormFile> files)
        {
            if(ModelState.IsValid)
            {
                if (files != null)
                {
                    var filepath = Path.Combine(_environment.WebRootPath, "mimg");
                    foreach (var item in files)
                    {
                        if (item.Length > 0)
                        {
                            var file = Path.Combine(filepath, item.FileName);

                            using (var getfile = new FileStream(file, FileMode.Create))
                            {
                                item.CopyTo(getfile);

                            }
                            product.ProductPhotos.Add(new ProductPhoto { AllPhotos = item.FileName });
                        }

                    }

                }
            }
          
           
            _repository.Update(product);

            return RedirectToAction("Index", "Product");
        }


        public IActionResult Details(Product product, int id)
        {
            _context.productPhotos.ToList();
            var details = _repository.GetById(id);
            return View(details);

        }


        public IActionResult Delete(int id)
        {
            _repository.Delete(_repository.GetById(id));
            return RedirectToAction("Index","Product");
        }

      
        

    }
}