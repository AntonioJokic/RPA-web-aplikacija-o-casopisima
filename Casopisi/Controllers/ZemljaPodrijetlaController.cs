using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Casopisi.Models;

namespace Casopisi.Controllers
{
    public class ZemljaPodrijetlaController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public ZemljaPodrijetlaController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }
        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisZemalja());
        }

        [HttpGet]
        public IActionResult Create()
        {
            int sljedeciId = _repozitorijUpita.SljedeciId();
            ZemljaPodrijetla zemlja = new ZemljaPodrijetla() { Id = sljedeciId };
            return View(zemlja);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Naziv")] ZemljaPodrijetla zemlja)
        {
            ModelState.Remove("Casopisi");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(zemlja);
                return RedirectToAction("Index");
            }
            return View(zemlja);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id < 1) { return NotFound(); }
            ZemljaPodrijetla zemlja = _repozitorijUpita.DohvatiZemljuSIdom(id);

            if (zemlja == null) { return NotFound(); }

            return View(zemlja);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id, Naziv")] ZemljaPodrijetla zemlja)
        {
            if (id != zemlja.Id) { return NotFound(); }
            ModelState.Remove("Casopisi");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(zemlja);
                return RedirectToAction("Index");
            }

            return View(zemlja);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id < 1) { return NotFound(); }

            var zemlja = _repozitorijUpita.DohvatiZemljuSIdom(Convert.ToInt16(id));

            if (zemlja == null) { return NotFound(); }

            return View(zemlja);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var zemlja = _repozitorijUpita.DohvatiZemljuSIdom(id);
            _repozitorijUpita.Delete(zemlja);
            return RedirectToAction("Index");
        }
    }
}
