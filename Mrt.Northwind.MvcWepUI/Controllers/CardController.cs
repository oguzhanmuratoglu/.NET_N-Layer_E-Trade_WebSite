using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mrt.Northwind.Business.Abstract;
using Mrt.Northwind.Entities.Concrete;
using Mrt.Northwind.MvcWepUI.Models;
using Mrt.Northwind.MvcWepUI.Services;

namespace Mrt.Northwind.MvcWepUI.Controllers
{
    public class CardController : Controller
    {
        private ICardSessionService _cardSessionService;
        private ICardService _cardService;
        private IProductService _productService;

        public CardController(ICardSessionService cardSessionService, ICardService cardService, IProductService productService)
        {
            _cardSessionService = cardSessionService;
            _cardService = cardService;
            _productService = productService;
        }

        public IActionResult AddToCard(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);
            var card = _cardSessionService.GetCard();
            _cardService.AddToCard(card, productToBeAdded);
            _cardSessionService.SetCard(card);

            TempData.Add("massage", String.Format("Your product , {0} , was succesfully added your card!",productToBeAdded.ProductName));

           return RedirectToAction("Index", "Product");
        }

        public IActionResult List()
        {
            
            var card = _cardSessionService.GetCard();
            CardSummaryViewModel cardListViewModel = new CardSummaryViewModel
            {
                Card = card,
            };
            return View(cardListViewModel);
        }

        public IActionResult Remove(int productId)
        {
            var card = _cardSessionService.GetCard();
            _cardService.RemoveToCart(card, productId);
            _cardSessionService.SetCard(card);

            TempData.Add("massage", String.Format("Your product was succesfully removed from your card!"));
            return RedirectToAction("List");


        }

        public IActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails()
            };

            return View(shippingDetailsViewModel);
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("massage", String.Format("Thank you {0}! Your order is in process", shippingDetails.FirstName));
            return View();

        }
    }
}