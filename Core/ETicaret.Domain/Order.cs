using ETicaret.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Domain
{
    public class Order:BaseEntity
    {
        public string Description{ get; set; }
        public string Address{ get; set; }
        public ICollection<Product> Products { get; set; }
        public Customer customer { get; set; }
    }
}
