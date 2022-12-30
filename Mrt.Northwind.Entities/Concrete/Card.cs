using System.Collections.Generic;
using System.Linq;

namespace Mrt.Northwind.Entities.Concrete
{
    public class Card
    {
        public Card()
        {
            CartLines = new List<CardLine>();
        }
        public List<CardLine> CartLines { get; set; }

        public decimal Total
        {
            get { return CartLines.Sum(c => c.Product.UnitPrice * c.Quantity); }
        }
    }
}