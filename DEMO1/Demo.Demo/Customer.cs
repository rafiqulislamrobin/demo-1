using demo1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Demo
{
    public class Customer : IEntity<Guid>
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
