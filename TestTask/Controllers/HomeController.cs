using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        DataBaseContext db = new DataBaseContext();
        public ActionResult Index()
        {
            return View("Main");
        }
    }
}
