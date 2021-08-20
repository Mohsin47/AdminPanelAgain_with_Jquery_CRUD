using AdminPanelAgain.Data;
using AdminPanelAgain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelAgain.Controllers
{
    public class HomeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeeController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            List<UserDb> list = new List<UserDb>();
            list = _db.UserDbs.ToList();
            ViewBag.Lists = list;
            return View();
        }
    }
}
