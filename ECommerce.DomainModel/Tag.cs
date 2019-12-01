using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainModel
{
   public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [Display(Name = "محصول")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public int ProductId { get; set; }

        [Display(Name = "کلمه کلیدی")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [MaxLength(150, ErrorMessage = "فیلد{0} نمی تواند بیشتر {1} کاراکتر باشد")]
        public string Title { get; set; }

        public Tag()
        {

        }

        public virtual Product Product { get; set; }
    }
}
