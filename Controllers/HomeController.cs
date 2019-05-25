using DisplayEmployees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisplayEmployees.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AutoComplete(string term)
        {
            Firma1Entities2 db = new Firma1Entities2();
            List<string> Employees = db
               .EmployeesFulls
               .Where(p => p.FullName.ToLower().Contains(term.ToLower()))
               .Select(p => p.FullName)
               .ToList();
            return Json(Employees, JsonRequestBehavior.AllowGet);
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