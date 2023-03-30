using Demo.Demo.BO;
using Demo.Demo.Repository;
using Demo.Demo.UnitOFWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Demo.Service
{
    public class DemoService : IDemoService
    {
        private readonly IDemoUnitOfWOrk _demoUnitOfWOrk;
        public DemoService(IDemoUnitOfWOrk customerRepositroy)
        {
            _demoUnitOfWOrk = customerRepositroy;
        }

        public void CreateCustomer(CustomerBO customerBO)
        {
            var customer = new Customer()
            {
                Id = Guid.NewGuid(),
                Address = customerBO.Address,
                Age = customerBO.Age,
                Name = customerBO.Name
            };

            _demoUnitOfWOrk.Customers.Add(customer);

            _demoUnitOfWOrk.Save();
        }

        public (IList<CustomerBO> records, int total, int totalDisplay) GetCutomers(int pageIndex, int pageSize,
       string searchText, string sortText)
        {
            var customerData = _demoUnitOfWOrk.Customers.GetDynamic(
            string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
            sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from customer in customerData.data
                              select new CustomerBO
                              {
                                  Name = customer.Name,
                                  Age = customer.Age,
                                  Address = customer.Address
                              }).ToList();

            return (resultData, customerData.total, customerData.totalDisplay);
        }
    }
}
