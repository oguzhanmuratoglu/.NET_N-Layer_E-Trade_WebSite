using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using Mrt.Northwind.Entities.Concrete;

namespace Mrt.Northwind.Business.Abstract
{
    public interface ICardService
    {
        void AddToCard(Card card, Product product);
        void RemoveToCart(Card card, int productId);
        List<CardLine> List(Card card);
    }
}
