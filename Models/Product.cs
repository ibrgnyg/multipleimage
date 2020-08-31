using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multipleİmage.Models
{
    public class Product:BaseModel
    {
        public Product()
        {
            ProductPhotos = new List<ProductPhoto>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="ürün adi zorunludur")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "ürün açıklama zorunludur")]
        public string Description { get; set; }

        [Required(ErrorMessage = "ürün fiyat zorunludur")]
        public int Price { get; set; }

        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }
    }
}
