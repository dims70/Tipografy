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
            return View(listSketch);
        }
        [HttpPost]
        public ActionResult AddToCart(int id)
        { if (Cart.CartCount() != 0)
            {
                foreach (Sketchs s in Cart.getCart())
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

        public ActionResult favorites() => View("Catalog", Cart.getCart());

        public ActionResult info() => View();

        public ActionResult price() => View();

        [HttpPost]
        public ActionResult send(string name,string surname, string patro,string number,string question)
        { var user = new Users() { Name = name, Surname = surname, Patronymic = patro, PhoneNumber = number };
            db.Users.Add(user);
            db.Callback.Add(new Callback() { idUser = user.idUser, Question = question });
            db.SaveChanges();
            return Content("<h1 style='color:white'>Вопрос отправлен!</h1>");
        }

        [HttpPost]
        public void Buy(int idsketch, 
            string surname, 
            string name, 
            string patro, 
            string phone, 
            string date, 
            string size, 
            int number, 
            string email,
            int tpdelivery,
            decimal sum,
            string desc
            )
        {
            var user = new Users() { Surname = surname, Name = name, Patronymic = patro, PhoneNumber = phone };
            db.Users.Add(user);
            db.SaveChanges();
            var ds = desc;
            var delivery = tpdelivery == 1 ? 500 : (tpdelivery == 2 ? 300 : (tpdelivery == 3 ? 200 : 0));
            var orderSum = sum + delivery;
            if (string.IsNullOrEmpty(ds)) {
                ds = "Пустой коментарий";
                db.Orders.Add(new Orders() { idUser = user.idUser, Date = Convert.ToDateTime(date), idSketch = idsketch, Size = size, Email = email, idTypeDelivery = tpdelivery, Sum = orderSum, Description = ds });
                db.SaveChanges();
            }
            else
            {
                db.Orders.Add(new Orders() { idUser=user.idUser, Date=Convert.ToDateTime(date),idSketch=idsketch, Size=size, Email=email, idTypeDelivery = tpdelivery, Sum=orderSum, Description=desc });
            }
            
        }

        [HttpGet]
        [HandleError(ExceptionType = typeof(NullReferenceException), View = "Error404")]
        public ActionResult Buy(int id)
        {
            var c = db.Sketchs.Find(id);
            if (c == null)
            {
                throw new NullReferenceException();
            }
            return View(c);
        }
    }
}