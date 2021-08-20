using AdminPanelAgain.Data;
using AdminPanelAgain.Models;
using AdminPanelAgain.Models.ViewModel;
using GraniteHouseRevison.Models.SD;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelAgain.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;


        [BindProperty]
        public RegisterViewModel registerViewModel { get; set; }

        public RegisterController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;

            registerViewModel = new RegisterViewModel()
            { 
                Countries = _db.Countries.ToList(),
                UserDbs = new Models.UserDb()
            };

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = _db.UserDbs.Include(m => m.Country);
            ViewBag.Country = new SelectList(_db.Countries.ToList(), "Id", "Name");

            return View(await list.ToListAsync());
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Country = new SelectList(_db.Countries.ToList(), "Id", "Name");

            return View(registerViewModel);
        }

        //[HttpPost,ValidateAntiForgeryToken]

        [HttpPost]
        public async Task<IActionResult> CreateTest(UserModel Obj)
        {
         
            if(!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            else
            {
                UserDb userDb = new UserDb();
                userDb.FullName = Obj.FullName;
                userDb.UserName = Obj.UserName;
                userDb.LastName = Obj.LastName;
                userDb.Password = Obj.Password;
                userDb.ConfirmPassword = Obj.ConfirmPassword;
                userDb.CountryIds = Obj.Country;
                userDb.Address = Obj.Address;
                userDb.IsCsharp = Obj.IsCsharp;
                //userDb.IsJava = Obj.IsJava;
                userDb.IsPython = Obj.IsPython;

                userDb.UpdatedOn = System.DateTime.Now;
                userDb.IsActive = true;
                userDb.CreatedBy = "Mohsinazhar";
                userDb.UpdatedBY = "Mohsinazhar";


                _db.Add(userDb);
                await _db.SaveChangesAsync();

                //registerViewModel.UserDbs.IsActive = true;
                //registerViewModel.UserDbs.CreatedBy = "Mohsinazhar";
                //registerViewModel.UserDbs.CreatedOn = DateTime.Now;
                //registerViewModel.UserDbs.UpdatedOn = DateTime.Now;
                //registerViewModel.UserDbs.UpdatedBY = "MohsinAzhar";
                //registerViewModel.UserDbs.CountryIds = 4;

                //_db.UserDbs.Add(registerViewModel.UserDbs);
                //await _db.SaveChangesAsync();


                //image code from here

                //string webrootPath = _webHostEnvironment.WebRootPath;
                ////Fetching the image from Server
                //var files = HttpContext.Request.Form.Files;

                //// finding the Uploaded Data against its id

                //var ProductFromDb = _db.UserDbs.Find(registerViewModel.UserDbs.Id);

                //if(files.Count!=0)
                //{
                //    //then add into Static detail Folder 
                //    var upload = Path.Combine(webrootPath, SD.ImagePath);
                //    var extentions = Path.GetExtension(files[0].FileName);

                //    //checking into filestream

                //    using (var filestream = new FileStream(Path.Combine(upload , registerViewModel.UserDbs.Id+extentions), FileMode.Create))
                //    {
                //        files[0].CopyTo(filestream);
                //    }
                //    ProductFromDb.Image = @"\" + SD.ImagePath + @"\" + registerViewModel.UserDbs.Id + extentions;

                //}
                //else
                //{
                //    var upload = Path.Combine(webrootPath, SD.ImagePath + @"\" + SD.DefaultImage);
                //    //System.IO
                //    System.IO.File.Copy(upload, webrootPath + @"\" + SD.ImagePath + @"\" +registerViewModel.UserDbs.Id + ".png");
                //}
                //await _db.SaveChangesAsync();

                return RedirectToAction("Index","Homee");
            }
        }

   

        public JsonResult EditDatas(int id)
        {
            try
            {
                var data = _db.UserDbs.Where(a => a.Id == id).FirstOrDefault();
                //return Json(data, JsonRequestBehavior.AllowGet);
                return Json(data);
            }
            catch (Exception)
            {
                return Json(null);
            }
        }


        public JsonResult Detaisl(int id)
            {
            try
            {
                var find = _db.UserDbs.Where(m => m.Id == id).FirstOrDefault();
                return Json(find);
            }
            catch (Exception)
            {

                return Json(null);

            }
        }


        [HttpPost]
        public JsonResult Delet(int id)
        {

            var find = _db.UserDbs.Where(m => m.Id == id).FirstOrDefault();
            if(find==null)
            {
                return Json(null);
            }
            else
            {
                find.IsActive = false;
                
                _db.UserDbs.Update(find);
                _db.SaveChanges();
            }
         
            return Json(find);
        }



        [HttpPost]
        public JsonResult UpdateClient(UserModel UserObj)
        {
            var find = _db.UserDbs.Where(m => m.Id== UserObj.Id).FirstOrDefault();
            if(find==null)
            {
                return Json(null);
            }
            else
            {
                find.FullName = UserObj.FullName;
                find.UserName = UserObj.UserName;
                find.LastName = UserObj.LastName;
                find.Address = UserObj.Address;
                find.IsCsharp = UserObj.IsCsharp;
                find.IsPython = UserObj.IsPython;
                find.IsJava = UserObj.IsJava;
                find.IsActive = UserObj.IsActive;


                find.UpdatedOn = System.DateTime.Now;
                find.CreatedBy = "Mohsinazhar";
                find.UpdatedBY = "Mohsinazhar";


                _db.Update(find);
                _db.SaveChanges();
            }


            return Json(null);
        }
       

    }
}
