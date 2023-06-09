using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppObuca.Models;

namespace WebAppObuca.Controllers
{
    public class BrendController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public BrendController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }

        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisBrend());
        }

        public IActionResult Create()
        {

            int sljedeciId = _repozitorijUpita.BrendSljedeciId();
            Brend brend = new Brend() { Id = sljedeciId };
            return View(brend);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Model")] Brend brend)
        {
            ModelState.Remove("Obuca");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(brend);
                return RedirectToAction("Index");
            }

            return View(brend);

        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var brend = _repozitorijUpita.DohvatiBrendSIdom(Convert.ToInt32(id));
            if (brend == null)
            {
                return NotFound();
            }
            return View(brend);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id,Model")] Brend brend)
        {
            if (id != brend.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Obuca");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(brend);
                return RedirectToAction("Index");
            }
            return View(brend);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var brend = _repozitorijUpita.DohvatiBrendSIdom(Convert.ToInt32(id));
            if (brend == null)
            {
                return NotFound();
            }
            return View(brend);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var brend = _repozitorijUpita.DohvatiBrendSIdom(Convert.ToInt32(id));
            _repozitorijUpita.Delete(brend);
            return RedirectToAction("Index");
        }
    }
}

