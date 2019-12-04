using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainModel
{
    public class ProductGroup
    {
        [Key]
        public int ProductGroupId { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string Title { get; set; }


        [Display(Name = "عنوان سر گروه")]
        public Nullable<int> ParentId { get; set; }


        //Relations
        public virtual ICollection<ProductGroup>  ListProductGroup { get; set; }

        [ForeignKey("ParentId")]
        public virtual ProductGroup  OneProductGroup { get; set; }

        public virtual ICollection<Product_ProductGroup> Product_ProductGroups { get; set; }


    }
}
