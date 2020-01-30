using OdeToRes.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToRes.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index(string name)
        {
            var NewModel = new GreetingsViewModel();
            NewModel.Name = name ?? "Maulik";
            NewModel.Message = ConfigurationSettings.AppSettings["Message"];
            return View(NewModel);
        }
    }
}