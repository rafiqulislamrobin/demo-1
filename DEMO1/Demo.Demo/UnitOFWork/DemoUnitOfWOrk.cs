using Demo.Demo.Repository;
using demo1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Demo.UnitOFWork
{
    public class DemoUnitOfWOrk : UnitOfWork, IDemoUnitOfWOrk
    {
        public ICustomerRepository Customers { get; private set; }

        public DemoUnitOfWOrk(DemoContext context,
            ICustomerRepository customers)
            : base((DbContext)context)
        {
            Customers = customers;
        }
    }
}
