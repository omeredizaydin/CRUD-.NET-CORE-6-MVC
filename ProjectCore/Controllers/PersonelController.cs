using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectCore.Models;

namespace ProjectCore.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();

        [Authorize]
        public IActionResult Index()
        {
            var degerler = c.Personels.Include(x=>x.Birim).ToList();
            return View(degerler);
        }
       
        [HttpGet]
        public IActionResult YeniPersonel()
        {
            //string query = from x in c.Birims.ToList();
            List<SelectListItem> degerler = (from x in c.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BirimAd,
                                                 Value = x.BirimID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("YeniPersonel");
        }
        public IActionResult YeniPersonel(Personel pd)
        {
            var per = c.Birims.Where(x => x.BirimID == pd.Birim.BirimID).FirstOrDefault();
            pd.Birim = per;
            c.Personels.Add(pd);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
