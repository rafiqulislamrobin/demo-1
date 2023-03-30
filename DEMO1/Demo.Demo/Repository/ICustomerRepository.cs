using demo1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Demo.Repository
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
    }
}