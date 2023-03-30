using demo1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Demo
{
   public class Ticket : IEntity<Guid>
    {
        public Guid Id { get; set; }
       
        public string Destination { get; set; }
        public int Fees { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
