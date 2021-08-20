using AdminPanelAgain.Data;
using AdminPanelAgain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelAgain.Controllers
{
    public class CountryController : Controller
    {

        private readonly ApplicationDbContext _db;


        public CountryController(ApplicationDbContext db)
        {

            _db = db;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_db.Countries.ToList());
        }


        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Country country)
        {
            if (country != null)
            {
                _db.Countries.Add(country);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var find = await _db.Countries.Where(m => m.Id == id).FirstOrDefaultAsync();
                if (find == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(find);
                }
            }
        }

        [HttpPost, ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int? id, Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(country);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View();
        }
    }
}

