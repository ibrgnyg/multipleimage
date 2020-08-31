using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multipleİmage.Models
{
    public class ProductPhoto:BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string AllPhotos { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
