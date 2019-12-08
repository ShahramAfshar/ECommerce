using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainModel
{
   public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public int ProductID { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "وب سایت")]
        public string WebSite { get; set; }

        [Display(Name = "متن نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Message { get; set; }

        [Display(Name = "تاریخ ثبت نظر")]
        public System.DateTime CreateDate { get; set; }
        public Nullable<int> ParentID { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Comment Comment2 { get; set; }
        public virtual Product Product { get; set; }
    }
}
