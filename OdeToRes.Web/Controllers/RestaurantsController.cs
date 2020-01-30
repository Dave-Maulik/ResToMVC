using OdeToRes.Data.Models;
using OdeToRes.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToRes.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;
        public RestaurantsController(IRestaurantData d)
        {
            db = d;
        }
        // GET: Restaurants
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.GetRes(id);
            if (model == null)
            {
                return View("Not_Found");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Restaurant restaruant)
        {
           
           if(ModelState.IsValid)
           {
                db.AddRes(restaruant);
                return RedirectToAction("Details", new { id = restaruant.Id });
           }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.GetRes(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Update(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id});
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.GetRes(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,FormCollection fs)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

    }
}