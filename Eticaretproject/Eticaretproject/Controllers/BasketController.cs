using eticaretsitesi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaretproject.Controllers
{
    public class BasketController : AndControllerBase
    {
        // GET: Basket
        [HttpPost]  

        public JsonResult AddProduct(int productID,int quantity)
        {
            var db = new AndDB();
            db.Baskets.Add(new eticaretsitesi.Entity.Basket
            {
                CreateDate = DateTime.Now,
                 CreateUserID=LoginUserID,
                 ProductID=productID,
                 Ouantity=quantity,
                 UserID=LoginUserID
            });
            var rt= db.SaveChanges();
            return Json(rt,JsonRequestBehavior.AllowGet);
        }

        [Route("Sepetim")]
        public ActionResult Index()
        {
            var db = new AndDB();
            var data = db.Baskets.Include("Product").Where(x => x.UserID == LoginUserID).ToList();
            return View();

        }

        public ActionResult Delete(int ID)
        {
            var db = new AndDB();
            var deleteItem = db.Baskets.Where(x => x.ID == ID).FirstOrDefault();
            db.Baskets.Remove(deleteItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}