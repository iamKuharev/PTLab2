using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP_Shop.Controllers
{
    public class BuyController : Controller
    {
        // GET: BuyController
        public IActionResult Buy()
        {
            return View();
        }

        // GET: BuyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BuyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BuyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BuyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BuyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BuyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
