using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mrt.Northwind.MvcWepUI.Models;
using Mrt.Northwind.MvcWepUI.Services;

namespace Mrt.Northwind.MvcWepUI.ViewComponents
{
    public class CardSummaryViewComponent : ViewComponent
    {
        private ICardSessionService _cardSessionService;

        public CardSummaryViewComponent(ICardSessionService cardSessionService)
        {
            _cardSessionService = cardSessionService;
        }


        public ViewViewComponentResult Invoke()
        {
            var model = new CardSummaryViewModel
            {
                Card = _cardSessionService.GetCard()
            };
            return View(model);
        }
    }
}
