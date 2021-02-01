using eticaretsitesi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaretproject.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {

        // GET: Admin/AdminLogin

        //globalde model bağlantısı yapıldı
        AndDB db = new AndDB();
        public ActionResult Index()
        {
            return View();
        }

        //login de giriş yap butonuna basıldığında çalışacak kod
        [HttpPost]
        public ActionResult Index(string email,string password )
        {
           var data= db.Users.Where(x => x.email == email && x.password == password && x.IsActive==true && x.IsAdmin==true).ToList();

            if (data.Count == 1)
            {
                //doğru ğiriş ise
                Session["AdminLoginUser"] = data.FirstOrDefault();//tüm tabloyu içine attık

                return Redirect("/admin");
            }
            else
            {
                //hatalı giriş se tekrar sayfaya dön return le
                return View();
            }


            
        }

    }
}