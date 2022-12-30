using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Mrt.Northwind.Entities.Concrete;
using Mrt.Northwind.MvcWepUI.ExtensionMethods;

namespace Mrt.Northwind.MvcWepUI.Services
{
    public class CardSessionService : ICardSessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CardSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetCard(Card card)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("card", card);
        }

        public Card GetCard()
        {
            Card cardToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Card>("card");
            
            if(cardToCheck == null )
            {
                _httpContextAccessor.HttpContext.Session.SetObject("card", new Card());
                cardToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Card>("card");
            }

                return cardToCheck;
            }
        }
    }

