﻿using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public interface ICategoryRepository:IRepository<Category>
    {
        IEnumerable<Category> GetCategory();
    }
}
