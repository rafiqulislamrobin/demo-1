﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext) => _dbContext = dbContext;


        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        } 


        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
