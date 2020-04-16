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
        public ActionResult FormAddSketch(string name,string material,int typesketch,decimal cost,string desc)
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
            var res = db.Sketchs
                .Select(x => new {
                    Id = id,
                name = x.Name,
                idtypesketch = x.idTypeSketch,
                material = x.Material,
                cost=x.Cost,
                desc = x.Description
            }).Where(x=>x.Id==id).First();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}