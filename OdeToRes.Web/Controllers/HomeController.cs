using OdeToRes.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToRes.Web.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantData db;
        public HomeController(IRestaurantData ldb)
        {
            db = ldb;
        }
        public ActionResult Index()
        {
            var Res = db.GetAll();
            return View(Res);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}