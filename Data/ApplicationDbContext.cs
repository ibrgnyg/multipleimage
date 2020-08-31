using Microsoft.EntityFrameworkCore;
using Multipleİmage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multipleİmage.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductPhoto> productPhotos { get; set; }
    }
}
