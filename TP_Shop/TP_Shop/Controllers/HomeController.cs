﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP_Shop.DataAccess.Entities;
using TP_Shop.DataAccess.Interfaceses;
using TP_Shop.Models;

namespace TP_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseRepository _purchaseRepository;


        public HomeController(IProductRepository productRepository, IPurchaseRepository purchaseRepository)
        {
            _productRepository = productRepository;
            _purchaseRepository = purchaseRepository;
        }

        public IActionResult Index(string promoCode)
        {
            var products = _productRepository.GetByPromoCode(promoCode).ToList();
            var productsViewModel = new List<ProductViewModel>();
            productsViewModel = products.Select(p => new ProductViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();
            return View(productsViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Buy(PurchaseViewModel purchaseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            purchaseViewModel.Date = DateTime.Now;
            var purchase = new Purchase()
            {
                ProductId = purchaseViewModel.ProductId,
                Address = purchaseViewModel.Address,
                Date = purchaseViewModel.Date,
                Person = purchaseViewModel.Person
            };

            _purchaseRepository.Create(purchase);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}