using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ECommerce.DomainModel
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "عنوان محصول")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [MaxLength(350, ErrorMessage = "فیلد{0} نمی تواند بیشتر {1} کاراکتر باشد")]
        public string ProductTitle { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [MaxLength(500, ErrorMessage = "فیلد{0} نمی تواند بیشتر {1} کاراکتر باشد")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیح کامل")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Text { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public int Price { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [DisplayFormat(DataFormatString ="{0: yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "عکس")]
        [MaxLength(50, ErrorMessage = "فیلد{0} نمی تواند بیشتر {1} کاراکتر باشد")]
        public string ImageName { get; set; }

        [Display(Name = "تعداد فروش")]
        public Nullable<int> CountSale { get; set; }

        //Relations

        public virtual ICollection<Product_ProductGroup>  Product_ProductGroups { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Product_Feature>  Product_Features { get; set; }
        public virtual ICollection<ProductGalery> ProductGaleries{ get; set; }


    }
}
