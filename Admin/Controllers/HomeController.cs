using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class HomeController : Controller
    {
        TipographyContext db = new TipographyContext();
        public ActionResult Index()
        {
            Table UserRequest = new Table() {
                ip = HttpContext.Request.UserHostAddress,
                userAgent = HttpContext.Request.UserAgent,
                sessionID = Session.SessionID 
            };
            var userSite = db.Statistic.Where(x => x.ip == UserRequest.ip && x.userAgent == UserRequest.userAgent).ToList();
            if (userSite.Count == 0)
            {
                db.Statistic.Add(UserRequest);
                db.SaveChanges();
            } 
            return View();
        }
        public ActionResult Catalog()
        {
            var listSketch = db.Sketchs.ToList();
            return PartialView(listSketch);
        }
        [HttpPost]
        public ActionResult AddToCart(int id)
        {   if(Cart.CartCount()!=0)
            {
                foreach(Sketchs s in Cart.getCart())
                {
                    if (id == s.idSketch)
                    {
                        return Json(
                            new
                            {
                                Error = "Товар уже есть в корзине"
                            }
                            );
                    }
                }
            }
            var sketch = db.Sketchs.Where(s => s.idSketch == id).ToList()[0];
            
            Cart.AddToCart(sketch);
            return Json(
                new
                {
                    CartCount = Cart.CartCount()
                }
                );
        }
        [HttpPost]
        public ActionResult RemoveFav(int id)
        {
            var sketch = db.Sketchs.Where(x => x.idSketch == id).ToList()[0];
            Cart.RemoveInCart(sketch);
            return Json(new
            {
                cartCount = Cart.CartCount()
            }
                );
        }

        public ActionResult favorites()
        {
            return View("Catalog", Cart.getCart());
        }
    }
}