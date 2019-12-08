using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DomainModel
{
   public class Comment
    {
        public int CommentID { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Message { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<int> ParentID { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Comment Comment2 { get; set; }
        public virtual Product Product { get; set; }
    }
}
