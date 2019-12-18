using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainModel
{
    public class ContactUs
    {
        [Key]
        public int ContactUsId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string Name { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "پرسش")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
       [DataType(DataType.MultilineText)]
        public int Question { get; set; }

    }
}
