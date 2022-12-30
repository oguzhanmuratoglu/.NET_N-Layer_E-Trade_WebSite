using System;
using System.Text;
using System.Threading.Tasks;

namespace Mrt.Northwind.Entities.Concrete
{
    public class CardLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
