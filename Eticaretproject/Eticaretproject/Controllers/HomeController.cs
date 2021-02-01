using Eticaretproject;//burada Controller.base vardı
using eticaretsitesi;
using eticaretsitesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaretproject.Controllers
{
    public class HomeController : AndControllerBase
    {
        // GET: Home
        AndDB db = new AndDB();
        public ActionResult Index()
        {
            ViewBag.IsLogin = this.IsLogin;
            var data = db.Products.OrderByDescending(x => x.CreateDate).Take(5).ToList();
            return View(data);
        }

        public PartialViewResult GetMenu()
        {
            
            var menus = db.Categories.Where(x => x.parentID == 0).ToList();
                return PartialView(menus);
        }
        [Route("Uye-Giris")]
        public ActionResult Login()
        {
            return View();
            
        }
        [HttpPost]
        [Route("Uye-Giris")]

        public ActionResult Login(string email,string password)
        {
            
            var Users = db.Users.Where(x=>x.email==email 
            && x.password==password 
            && x.IsActive==true 
            && x.IsAdmin==false).ToList();

            if (Users.Count==1)
            {
                //giriş ok
                Session["LoginUserID"] = Users.FirstOrDefault().ID;
              Session["LoginUser"] = Users.FirstOrDefault();
                return Redirect("/");
            }
            else
            {
                ViewBag.Error = "Hatalı kullanıcı adı veya şifre ";
                return View();
            }

           
           
        }


        [Route("Uye-Kayit")]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]

        [Route("Uye-Kayit")]
        public ActionResult CreateUser(User entity)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.CreateUserID = 1;
                entity.IsActive = true;
                entity.IsAdmin = false;

                db.Users.Add(entity);
                db.SaveChanges();
                return Redirect("/");

            }
            catch (Exception ex)
            {

                return View();
            }
           
            
        }
    }
}