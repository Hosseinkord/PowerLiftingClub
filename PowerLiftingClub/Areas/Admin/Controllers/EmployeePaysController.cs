using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;

namespace PowerLiftingClub.Areas.Admin.Controllers
{
    public class EmployeePaysController : Controller
    {
        private IEmployeePay employeePayRepository;
        private IEmployee employeeRepository;

        private ClubContext db = new ClubContext();

        public EmployeePaysController()
        {
            employeePayRepository = new EmployeePayRepository(db);
            employeeRepository = new EmployeeRepository(db);
        }

        // GET: Admin/EmployeePays
        public ActionResult Index()
        {
            return View(employeePayRepository.GetAllEmployeePay());
        }

        // GET: Admin/EmployeePays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeePay employeePay = employeePayRepository.GetEmployeePayById(id.Value);
            if (employeePay == null)
            {
                return HttpNotFound();
            }
            return View(employeePay);
        }

        // GET: Admin/EmployeePays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/EmployeePays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PayID,EmployeeID,Pay")] EmployeePay employeePay)
        {
            if (ModelState.IsValid)
            {
                employeePayRepository.InsertEmployeePay(employeePay);
                employeePayRepository.Save();
                return RedirectToAction("Index");
            }

            return View(employeePay);
        }

        // GET: Admin/EmployeePays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeePay employeePay = employeePayRepository.GetEmployeePayById(id.Value);
            if (employeePay == null)
            {
                return HttpNotFound();
            }
            return View(employeePay);
        }

        // POST: Admin/EmployeePays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PayID,EmployeeID,Pay")] EmployeePay employeePay)
        {
            if (ModelState.IsValid)
            {
                employeePayRepository.UpdateEmployeePay(employeePay);
                employeePayRepository.Save();
                return RedirectToAction("Index");
            }
            return View(employeePay);
        }

        // GET: Admin/EmployeePays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeePay employeePay = employeePayRepository.GetEmployeePayById(id.Value);
            if (employeePay == null)
            {
                return HttpNotFound();
            }
            return View(employeePay);
        }

        // POST: Admin/EmployeePays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeePay employeePay = employeePayRepository.GetEmployeePayById(id);
            employeePayRepository.DeleteEmployeePay(employeePay);
            employeePayRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                employeeRepository.Dispose();
                employeePayRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
