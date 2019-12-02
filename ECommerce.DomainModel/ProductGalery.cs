using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainModel
{
  public  class ProductGalery
    {
        public int GalleryID { get; set; }

        [Display(Name = "کالا")]
        public int ProductID { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        public virtual Product Products { get; set; }
    }
}
