using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;

namespace PowerLiftingClub.Areas.Admin.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployee employeeRepository;
        private ClubContext db = new ClubContext();

        public EmployeesController()
        {
            employeeRepository = new EmployeeRepository(db);
        }

        // GET: Admin/Employees
        public ActionResult Index()
        {
            return View(employeeRepository.GetAllEmployee());
        }

        // GET: Admin/Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeRepository.GetEmployeeById(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Admin/Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Name,Familly,Address,Phone,Preambles,Terms,Age,Grade,ImageName,Type")] Employee employee, HttpPostedFileBase imgUpEm)
        {
            if (ModelState.IsValid)
            {
                if (imgUpEm != null)
                {
                    employee.ImageName = Guid.NewGuid() + Path.GetExtension(imgUpEm.FileName);
                    imgUpEm.SaveAs(Server.MapPath("/EmployeeImages/" + employee.ImageName));
                }
                employeeRepository.InsertEmployee(employee);
                employeeRepository.Save();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Admin/Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeRepository.GetEmployeeById(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Admin/Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,Name,Familly,Address,Phone,Preambles,Terms,Age,Grade,ImageName,Type")] Employee employee,HttpPostedFileBase imgUpEm)
        {
            if (ModelState.IsValid)
            {
                if (imgUpEm != null)
                {
                    if (employee.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/EmployeeImages/" + employee.ImageName));
                    }


                    employee.ImageName = Guid.NewGuid() + Path.GetExtension(imgUpEm.FileName);
                    imgUpEm.SaveAs(Server.MapPath("/EmployeeImages/" + employee.ImageName));
                }
                employeeRepository.UpdateEmployee(employee);
                employeeRepository.Save();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Admin/Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeRepository.GetEmployeeById(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Admin/Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = employeeRepository.GetEmployeeById(id);
            if (employee.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/EmployeeImages/" + employee.ImageName));
            }
            employeeRepository.DeleteEmployee(employee);
            employeeRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                employeeRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
