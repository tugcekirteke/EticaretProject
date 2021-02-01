using Eticaretproject;
using eticaretsitesi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaretproject.Controllers
{
    public class CategoryController : AndControllerBase
    {
        // GET: Category
        [Route("Kategori/{isim}/{ID}")]
        public ActionResult Index(string isim,int ID)
        {
            var db = new AndDB();
        var data = db.Products.Where(x => x.IsActive == true && x.CategoryID == ID).ToList();
           ViewBag.category = db.Categories.Where(x => x.ID == ID).FirstOrDefault();

            return View(data);
        }
    }
}