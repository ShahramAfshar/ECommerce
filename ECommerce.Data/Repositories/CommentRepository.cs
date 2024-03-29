﻿using ECommerce.Data.DatabaseContext;
using ECommerce.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories
{
 

        public interface ICommentRepository : IRepository<Comment>
        {
            //------Definition Private Functions Model -------------//
            IEnumerable<Comment> GetForProduct(int productId);

        }

        public class CommentRepository : Repository<Comment>, ICommentRepository
    {

            private readonly DbContext db;
            public CommentRepository(DbContext dbContext) : base(dbContext)
            {
                this.db = (this.db ?? (MyDbContext)db);
            }

        public IEnumerable<Comment> GetForProduct(int productId)
        {
            return GetAll().Where(c => c.ProductID == productId);
        }

        //public IList<User> GetActiveUsers()
        //{
        //    var users = GetAll().Where(u => u.IsActive)
        //        .ToList();
        //    return users;
        //}




    }
}
