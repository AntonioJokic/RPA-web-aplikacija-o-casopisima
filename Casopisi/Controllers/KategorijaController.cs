using Casopisi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;
using Casopisi.Models;

namespace Casopisi.Controllers
{
    public class KategorijaController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public KategorijaController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }
        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisKategorija());
        }

        [HttpGet]
        public IActionResult Create()
        {
            int sljedeciId = _repozitorijUpita.SljedeciId();
            Kategorija kategorija = new Kategorija() { Id = sljedeciId };
            return View(kategorija);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Naziv")] Kategorija kategorija)
        {
            ModelState.Remove("Casopisi");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(kategorija);
                return RedirectToAction("Index");
            }
            return View(kategorija);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id < 1) { return NotFound(); }
            Kategorija kategorija = _repozitorijUpita.DohvatiKategorijuSIdom(id);

            if (kategorija == null) { return NotFound(); }

            return View(kategorija);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id, Naziv")] Kategorija kategorija)
        {
            if (id != kategorija.Id) { return NotFound(); }
            ModelState.Remove("Casopisi");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(kategorija);
                return RedirectToAction("Index");
            }

            return View(kategorija);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id < 1) { return NotFound(); }

            var kategorija = _repozitorijUpita.DohvatiKategorijuSIdom(Convert.ToInt16(id));

            if (kategorija == null) { return NotFound(); }

            return View(kategorija);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var kategorija = _repozitorijUpita.DohvatiKategorijuSIdom(id);
            _repozitorijUpita.Delete(kategorija);
            return RedirectToAction("Index");
        }
    }
}
