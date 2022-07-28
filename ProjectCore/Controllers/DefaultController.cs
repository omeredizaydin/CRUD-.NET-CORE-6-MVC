using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.Models;

namespace ProjectCore.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
       // [Authorize]
        public IActionResult Index()
        {
            var vals = c.Birims.ToList();           

            return View(vals);
        }
        [HttpGet]
        public IActionResult YeniBirim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniBirim(Birim birim)
        {
            c.Birims.Add(birim);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimSil(int id)
        {
            var vals = c.Birims.Find(id);
            c.Birims.Remove(vals);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimGetir(int id)
        {
            var depart = c.Birims.Find(id);
            return View("BirimGetir", depart);
        }
        public IActionResult BirimGuncelle(Birim birim)
        {
            var dep = c.Birims.Find(birim.BirimID);
            dep.BirimAd = birim.BirimAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
