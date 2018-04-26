﻿using ShopCham.Data.Infrastructure;
using ShopCham.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCham.Data.Repositories
{
    public class PostTagRepository : RepositoryBase<PostTag>
    {
        public PostTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
