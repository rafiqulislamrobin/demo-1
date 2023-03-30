using Demo.Demo.Repository;
using Demo.Demo;
using demo1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Demo.Repository;

public class CustomerRepository : Repository<Customer, Guid>, ICustomerRepository
{
    public CustomerRepository(DemoContext context)
       : base((DbContext)context)
    {

    }
}
