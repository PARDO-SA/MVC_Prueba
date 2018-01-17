using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Prueba.Controllers
{
    public class HelloWordController : Controller
    {
        // GET: HelloWord
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET:/HelloWord/Welome/
        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;
            return View();
        }
    }
}