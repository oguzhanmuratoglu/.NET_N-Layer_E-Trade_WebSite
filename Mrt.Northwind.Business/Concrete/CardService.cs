using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mrt.Northwind.Business.Abstract;
using Mrt.Northwind.Entities.Concrete;

namespace Mrt.Northwind.Business.Concrete
{
    public class CardService:ICardService
    {
        public void AddToCard(Card card, Product product)
        {
            CardLine cardLine = card.CartLines.FirstOrDefault(c=>c.Product.ProductId==product.ProductId);

            if (cardLine != null)
            {
                cardLine.Quantity++;
                return;
            }

            card.CartLines.Add(new CardLine{Product = product,Quantity = 1});
        }

        public void RemoveToCart(Card card, int productId)
        {
            card.CartLines.Remove(card.CartLines.FirstOrDefault(c => c.Product.ProductId == productId));
        }

        public List<CardLine> List(Card card)
        {
            return card.CartLines;
        }
    }
}
