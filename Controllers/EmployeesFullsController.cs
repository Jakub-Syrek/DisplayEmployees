using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DisplayEmployees.Models;

namespace DisplayEmployees.Controllers
{
    public class EmployeesFullsController : Controller
    {
        private Firma1Entities2 db = new Firma1Entities2();
        private List<EmployeesFull> lista = new List<EmployeesFull>();
        
        /*
        // GET: EmployeesFulls
        public async Task<ActionResult> Index()
        {
            return View(await db.EmployeesFulls.ToListAsync());
        }
        */


        //Post: EmployeesFulls
        
        public async Task<ActionResult> Index(string searchTerm)
        {
            var listOFManagers = new List<string>();

            var ManagerQry = from d in db.EmployeesFulls
                             orderby d.ReportingToID.ToString()
                             select d.ReportingToID.ToString();

            listOFManagers.AddRange(ManagerQry.Distinct());
            ViewBag.reportingToId = new SelectList(listOFManagers);

            if (string.IsNullOrEmpty(searchTerm))
            {
                lista = await db.EmployeesFulls.ToListAsync();
            }
            else
            {
                lista = await db.EmployeesFulls.Where(x => x.FullName.StartsWith(searchTerm)).ToListAsync();
            }


            return View(lista);
        }
        [HttpPost]
        public async Task<ActionResult> Index(string? searchTerm , string? startDate , string? reportingToId)
        {
                var listOFManagers = new List<string>();

                var ManagerQry = from d in db.EmployeesFulls
                           orderby d.ReportingToID.ToString()
                           select d.ReportingToID.ToString();

                listOFManagers.AddRange(ManagerQry.Distinct());
                ViewBag.reportingToId = new SelectList(listOFManagers);


                if (string.IsNullOrEmpty(searchTerm) && string.IsNullOrEmpty(startDate) && (string.IsNullOrEmpty(reportingToId)))
                {
                lista = await db.EmployeesFulls.ToListAsync();                
                }
                else if (!string.IsNullOrEmpty(searchTerm) && string.IsNullOrEmpty(startDate) && (string.IsNullOrEmpty(reportingToId)))
                {
                lista = await db.EmployeesFulls.Where(x => x.FullName.StartsWith(searchTerm)).ToListAsync();
                }
                else if (string.IsNullOrEmpty(searchTerm) && (!string.IsNullOrEmpty(startDate)) && (string.IsNullOrEmpty(reportingToId)))
                {
                DateTime date = DateTime.Parse(startDate);
                lista = await db.EmployeesFulls.Where(l => l.JoiningDate <= date).ToListAsync();
                }
                else if (string.IsNullOrEmpty(searchTerm) && (string.IsNullOrEmpty(startDate)) && (!string.IsNullOrEmpty(reportingToId)))
                {
                lista = await db.EmployeesFulls.Where(x => x.ReportingToID.ToString() == reportingToId).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(searchTerm) && (!string.IsNullOrEmpty(startDate)) && (string.IsNullOrEmpty(reportingToId)))
                {                
                lista = await db.EmployeesFulls.Where(x => x.FullName.StartsWith(searchTerm)).ToListAsync();                
                }
                else if ((!string.IsNullOrEmpty(searchTerm) && (string.IsNullOrEmpty(startDate)) && (!string.IsNullOrEmpty(reportingToId))))
                {
                lista = await db.EmployeesFulls.Where(x => x.FullName.StartsWith(searchTerm)).ToListAsync();
                }
                else if ((string.IsNullOrEmpty(searchTerm) && (!string.IsNullOrEmpty(startDate)) && (!string.IsNullOrEmpty(reportingToId))))
                {
                DateTime date = DateTime.Parse(startDate);
                lista = await db.EmployeesFulls.Where(l => l.JoiningDate <= date).ToListAsync();
                lista = lista.Where(x => x.ReportingToID.ToString() == reportingToId).ToList();
                }
                else if (!string.IsNullOrEmpty(searchTerm) && (!string.IsNullOrEmpty(startDate)) && !(string.IsNullOrEmpty(reportingToId)))
                {
                lista = await db.EmployeesFulls.Where(x => x.FullName.StartsWith(searchTerm)).ToListAsync();
                }
                /*
                if (string.IsNullOrEmpty(startDate))
                {
                  //lista = await db.EmployeesFulls.ToListAsync();
                }
                else
                {
                DateTime date = DateTime.Parse(startDate);
                lista = await db.EmployeesFulls.Where(l => l.JoiningDate <= date).ToListAsync();                
                }
                if (string.IsNullOrEmpty(reportingToId ))
                {                
                }
                else
                {                
                lista = await db.EmployeesFulls.Where(x => x.ReportingToID.ToString() == reportingToId).ToListAsync();
                }
                */
            return View(lista);
         
        }
        // GET: EmployeesFulls/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesFull employeesFull = await db.EmployeesFulls.FindAsync(id);
            if (employeesFull == null)
            {
                return HttpNotFound();
            }
            return View(employeesFull);
        }

        // GET: EmployeesFulls/Create
        public ActionResult Create()
        {
            return View();
        }
        public JsonResult Autocomplete(string term)

        {
            using (Firma1Entities2 db = new Firma1Entities2())
            {

                List<string> Employees = db
                .EmployeesFulls
                .Where(p => p.FullName.ToLower().Contains(term.ToLower()))
                .Select(p => p.FullName)
                .ToList();
                return Json(Employees, JsonRequestBehavior.AllowGet);
            }
        }
        // POST: EmployeesFulls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,FullName,JoiningDate,ReportingToID")] EmployeesFull employeesFull)
        {
            if (ModelState.IsValid)
            {
                db.EmployeesFulls.Add(employeesFull);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employeesFull);
        }

        // GET: EmployeesFulls/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesFull employeesFull = await db.EmployeesFulls.FindAsync(id);
            if (employeesFull == null)
            {
                return HttpNotFound();
            }
            return View(employeesFull);
        }

        // POST: EmployeesFulls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,FullName,JoiningDate,ReportingToID")] EmployeesFull employeesFull)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeesFull).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employeesFull);
        }

        // GET: EmployeesFulls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesFull employeesFull = await db.EmployeesFulls.FindAsync(id);
            if (employeesFull == null)
            {
                return HttpNotFound();
            }
            return View(employeesFull);
        }

        // POST: EmployeesFulls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EmployeesFull employeesFull = await db.EmployeesFulls.FindAsync(id);
            db.EmployeesFulls.Remove(employeesFull);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
       
    }
}
