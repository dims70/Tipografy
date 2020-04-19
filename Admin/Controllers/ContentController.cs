using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class ContentController : Controller
    {
        TipographyContext db = new TipographyContext();
        public ActionResult Admin()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Statistic()
        {
            var stats = db.Statistic.ToList();
            return PartialView(stats);
        }
        [HttpGet]
        public ActionResult Content()
        {
            var sketchs = db.Sketchs.ToList();
            return PartialView(sketchs);
        }
        [HttpGet]
        public ActionResult FormAddSketch(string name, string material, int typesketch, decimal cost, string desc)
        {
            db.Sketchs.Add(new Sketchs()
            {
                Name = name,
                idTypeSketch = typesketch,
                Material = material,
                Cost = cost,
                Description = desc
            });
            db.SaveChanges();
            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult getSketch(int id)
        {
            var res = db.Sketchs.Where(x => x.idSketch == id)
                .Select(x => new
                {
                    Id = id,
                    name = x.Name,
                    idtypesketch = x.idTypeSketch,
                    material = x.Material,
                    cost = x.Cost,
                    desc = x.Description
                }).ToList()[0];
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult editsketch(string name, string material, decimal cost, string desc, int idsketch, int idtypesketch)
        {
            var sketch = db.Sketchs.Where(x => x.idSketch == idsketch).First();
            sketch.Name = name;
            sketch.Material = material;
            sketch.Cost = cost;
            sketch.Description = desc;
            db.SaveChanges();
            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult deletesketch(int id)
        {
            var sk = db.Sketchs.Find(id);
            db.Sketchs.Remove(sk);
            db.SaveChanges();
            return new EmptyResult();
        }
        [HttpGet]
        public ActionResult typesketch()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult addtypesk(string name)
        {
            var type = new TypesSketch() { Name = name };
            db.TypesSketch.Add(type);
            db.SaveChanges();
            return Content($@"<tr id='{type.idTypeSketch}'><td style='background: black'>
                        <span style='color: white; font-size:20px; background: black; cursor: pointer' id='deltypesketch'>
                        <a data-ajax='true' 
                            data-ajax-method='Get'"+
                            $"data-ajax-success=\"Mess({"\'Эскиз удален\'"}"+$", \'{type.idTypeSketch}\')\"" +
                            $" href='/Content/deltypesk/{type.idTypeSketch}'" +">x" +
                        "</a>" +
                        "</span>" +
                                                          "</td>" +
                $"<td style='background:white'>{name}" +
                $"</td></tr> ");
        }
        [HttpGet]
        public ActionResult deltypesk(dynamic id)
        {
            int ID = Convert.ToInt32(id);
            db.TypesSketch.Remove(db.TypesSketch.Find(ID));
            db.SaveChanges();
            return Content("");
        }
        [HttpGet]
        public ActionResult orders()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult finishOrder(int id)
        {
            db.Orders.Remove(db.Orders.Find(id));
            db.SaveChanges();
            return new JavaScriptResult() { Script="alert(Заказ завершен и удален из списка)"};
        }

        [HttpGet]
        public ActionResult Callback()
        {
            return PartialView();
        }

    }
}