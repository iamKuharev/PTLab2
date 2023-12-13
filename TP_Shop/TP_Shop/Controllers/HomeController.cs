using Microsoft.AspNetCore.Mvc;
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

        private readonly ILogger<HomeController> _logger;

        public HomeController(IProductRepository productRepository, IPurchaseRepository purchaseRepository, ILogger<HomeController> logger)
        {
            _productRepository = productRepository;
            _purchaseRepository = purchaseRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll().ToList();
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