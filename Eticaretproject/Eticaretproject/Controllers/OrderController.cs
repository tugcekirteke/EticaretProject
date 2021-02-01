using eticaretsitesi;
using eticaretsitesi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaretproject.Controllers
{
    public class OrderController : AndControllerBase
    {
        // GET: Order
        [Route("Siparisve")]
        public ActionResult AddressList()
        {
            var db = new AndDB();
            var data = db.Addresses.Where(x => x.UserID==LoginUserID).ToList();
            return View(data);
        }
        public ActionResult CreateUserAddresses()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUserAddresses(UserAddress entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.CreateUserID = LoginUserID;
            entity.IsActive = true;
            entity.UserID = LoginUserID;
            var db = new AndDB();
            db.Addresses.Add(entity);
            db.SaveChanges();
            return RedirectToAction("AddressList");
        }

        public ActionResult CreateOrder(int ID)
        {
             var db = new AndDB();


            var sepet = db.Baskets.Include("Product").Where(x => x.UserID == LoginUserID).ToList(); ;
            Order order = new Order();
            order.CreateDate = DateTime.Now;
            order.CreateUserID = LoginUserID;
            order.StatusID = 2;
            order.ToplamUrunFiyat = sepet.Sum(x => x.Product.fiyat);
            order.ToplamVergi = sepet.Sum(x => x.Product.vergi);
            order.ToplamIndirim = sepet.Sum(x => x.Product.indirim);
            order.TopplamFiyat = order.ToplamUrunFiyat + order.TopplamFiyat;
            order.UserAddressID = ID;
            order.UserID = LoginUserID;
            order.BasketDetail = new List<BasketDetail>();
            foreach (var item in sepet)
            {
                order.BasketDetail.Add(new BasketDetail
                {
                    CreateDate = DateTime.Now,
                    CreateUserID = LoginUserID,
                    ProductID = item.ProductID,
                    //Quantity = item.Quantity
                });
                db.Baskets.Remove(item);
            }
            db.Orders.Add(order);

            db.SaveChanges();

            return RedirectToAction("Detail", new { id = order.ID });
        }

        public ActionResult Detail(int ID)
        {
            var db = new AndDB();
            var data = db.Orders.Include("BasketDetail")
                .Include("BasketDetail.Product")
                .Include("OrderPayments")
                .Include("Status")
                .Include("UserAddress")
                .Where(x => x.ID == ID).FirstOrDefault();
            return View(data);
        }
        [Route("Siparislerim")]
        public ActionResult Index()
        {
            var db = new AndDB();
            var data = db.Orders.Include("Status").Where(x => x.UserID == LoginUserID).ToList();
            return View(data);
        }
        public ActionResult Pay(int ID)
        {
            var db = new AndDB();
            var order = db.Orders.Where(x => x.ID == ID).FirstOrDefault();
            order.StatusID = 6;
            db.SaveChanges();
            return RedirectToAction("Detail", new { ID = order.ID });
        }


    }
}