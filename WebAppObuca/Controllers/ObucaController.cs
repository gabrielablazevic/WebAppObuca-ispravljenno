using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppObuca.Models;

namespace WebAppObuca.Controllers
{
    public class ObucaController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public ObucaController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }

        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisObuca());
        }

        public IActionResult Create()
        {
            ViewData["BrendId"] = new SelectList(_repozitorijUpita.PopisBrend(), "Id", "Model");
            int sljedeciId = _repozitorijUpita.SljedeciId();
            Obuca obuca = new Obuca() { Id = sljedeciId };
            return View(obuca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Model,Cijena,SlikaUrl,BrendId")] Obuca obuca)
        {
            ModelState.Remove("Brend");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(obuca);
                return RedirectToAction("Index");
            }

            ViewData["BrendId"] = new SelectList(_repozitorijUpita.PopisBrend(), "Id", "Model", obuca.BrendId);
            return View(obuca);

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            Obuca obuca = _repozitorijUpita.DohvatiObucuSIdom(id);

            if (obuca == null) { return NotFound(); }

            ViewData["BrendId"] = new SelectList(_repozitorijUpita.PopisBrend(), "Id", "Model", obuca.BrendId);
            return View(obuca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id,Model,Cijena,SlikaUrl,BrendId")] Obuca obuca)
        {
            if (id != obuca.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Brend");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(obuca);
                return RedirectToAction("Index");
            }

            ViewData["BrendId"] = new SelectList(_repozitorijUpita.PopisBrend(), "Id", "Model", obuca.BrendId);
            return View(obuca);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            var obuca = _repozitorijUpita.DohvatiObucuSIdom(Convert.ToInt16(id));

            if (obuca == null)
            {
                return NotFound();
            }

            return View(obuca);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obuca = _repozitorijUpita.DohvatiObucuSIdom(id);
            _repozitorijUpita.Delete(obuca);
            return RedirectToAction("Index");

        }


        public ActionResult SearchIndex(string obucaBrend, string searchString)
        {
            var brend = new List<string>();

            var brendUpit = _repozitorijUpita.PopisBrend();

            ViewData["obucaBrend"] = new SelectList(_repozitorijUpita.PopisBrend(), "Model", "Model", brendUpit);

            var obuca = _repozitorijUpita.PopisObuca();

            if (!String.IsNullOrWhiteSpace(searchString))
            {
                obuca = obuca.Where(s => s.Model.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            if (string.IsNullOrWhiteSpace(obucaBrend))
                return View(obuca);
            else
            {
                return View(obuca.Where(x => x.Brend.Model == obucaBrend));
            }

        }


    }
}

