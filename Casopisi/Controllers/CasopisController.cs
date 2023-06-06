using Casopisi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Casopisi.Models;

namespace Casopisi.Controllers
{
    public class CasopisController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public CasopisController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }
        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisCasopisa());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv");
            ViewData["ZemljaPodrijetlaId"] = new SelectList(_repozitorijUpita.PopisZemalja(), "Id", "Naziv");
            int sljedeciId = _repozitorijUpita.SljedeciId();
            Casopis casopis = new Casopis() { Id = sljedeciId };
            return View(casopis);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Naziv, KategorijaId, Cijena, ZemljaPodrijetlaId, Urednik, SlikaUrl")] Casopis casopis)
        {
            ModelState.Remove("Kategorija");
            ModelState.Remove("ZemljaPodrijetla");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(casopis);
                return RedirectToAction("Index");
            }
            return View(casopis);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id < 1) { return NotFound(); }
            Casopis casopis = _repozitorijUpita.DohvatiCasopisSIdom(id);

            if (casopis == null) { return NotFound(); }

            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", casopis.KategorijaId);
            ViewData["ZemljaPodrijetlaId"] = new SelectList(_repozitorijUpita.PopisZemalja(), "Id", "Naziv", casopis.ZemljaPodrijetlaId);
            return View(casopis);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id, Naziv, KategorijaId, Cijena, ZemljaPodrijetlaId, Urednik, SlikaUrl")] Casopis casopis)
        {
            if (id != casopis.Id) { return NotFound(); }
            ModelState.Remove("Kategorija");
            ModelState.Remove("ZemljaPodrijetla");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(casopis);
                return RedirectToAction("Index");
            }

            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", casopis.KategorijaId);
            ViewData["ZemljaPodrijetlaId"] = new SelectList(_repozitorijUpita.PopisZemalja(), "Id", "Naziv", casopis.ZemljaPodrijetlaId);
            return View(casopis);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id < 1) { return NotFound(); }

            var casopis = _repozitorijUpita.DohvatiCasopisSIdom(Convert.ToInt16(id));

            if (casopis == null) { return NotFound(); }

            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", casopis.KategorijaId);
            ViewData["ZemljaPodrijetlaId"] = new SelectList(_repozitorijUpita.PopisZemalja(), "Id", "Naziv", casopis.ZemljaPodrijetlaId);
            return View(casopis);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var casopis = _repozitorijUpita.DohvatiCasopisSIdom(id);
            _repozitorijUpita.Delete(casopis);
            return RedirectToAction("Index");
        }

        public ActionResult SearchIndex(string casopisKategorija, string casopisZemlja, string searchString)
        {
            var kategorija = new List<string>();
            var zemlja = new List<string>();

            var kategorijaUpit = _repozitorijUpita.PopisKategorija();
            var zemljaUpit = _repozitorijUpita.PopisZemalja();

            ViewData["casopisKategorija"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Naziv", "Naziv", kategorijaUpit);
            ViewData["casopisZemlja"] = new SelectList(_repozitorijUpita.PopisZemalja(), "Naziv", "Naziv", zemljaUpit);

            var casopisi = _repozitorijUpita.PopisCasopisa();

            if (!String.IsNullOrWhiteSpace(searchString))
            {
                casopisi = casopisi.Where(s => s.Naziv.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            if (string.IsNullOrWhiteSpace(casopisKategorija))
                return View(casopisi);
            else
            {
                return View(casopisi.Where(x => x.Kategorija.Naziv == casopisKategorija && x.ZemljaPodrijetla.Naziv == casopisZemlja));
            }

        }
    }
}