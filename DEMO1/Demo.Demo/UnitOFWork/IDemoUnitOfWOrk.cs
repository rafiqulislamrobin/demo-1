using Demo.Demo.Repository;
using demo1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Demo.UnitOFWork;

public interface IDemoUnitOfWOrk : IUnitOfWork
{
    ICustomerRepository Customers { get; }
}
