using Demo.Demo.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Demo.Service
{
    public interface IDemoService
    {
        void CreateCustomer(CustomerBO customerBO);
        (IList<CustomerBO> records, int total, int totalDisplay) GetCutomers(int pageIndex, int pageSize,
       string searchText, string sortText);
    }
}
