
using Eticaretproject;
using eticaretsitesi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaretproject.Controllers
{
    public class UrunController : AndControllerBase
    {
        //Ürün detay sayfası

        // GET: Urun
        [Route("Urun/{title}/{id}")]

        public ActionResult Detail(string title,int ID)
        {
            var db = new AndDB();
            var prod = db.Products.Where(x => x.ID == ID).FirstOrDefault();
            return View(prod);

        }
    }
}