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
    public class UserSalariesController : Controller
    {
        private IUser userRepository;
        private IUserSalary userSalaryRepository;
        private ClubContext db = new ClubContext();

        public UserSalariesController()
        {
            userRepository = new UserRepository(db);
            userSalaryRepository = new UserSalaryRepository(db);
        }

        // GET: Admin/UserSalaries
        public ActionResult Index()
        {
            return View(userSalaryRepository.GetAllUserSalary());
        }

        // GET: Admin/UserSalaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSalary userSalary = userSalaryRepository.GetUserSalaryById(id.Value);
            if (userSalary == null)
            {
                return HttpNotFound();
            }
            return View(userSalary);
        }

        // GET: Admin/UserSalaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/UserSalaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PayID,UserID,Pay")] UserSalary userSalary)
        {
            if (ModelState.IsValid)
            {
                userSalaryRepository.InsertUserSalary(userSalary);
                userSalaryRepository.Save();
                return RedirectToAction("Index");
            }

            return View(userSalary);
        }

        // GET: Admin/UserSalaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSalary userSalary = userSalaryRepository.GetUserSalaryById(id.Value);
            if (userSalary == null)
            {
                return HttpNotFound();
            }
            return View(userSalary);
        }

        // POST: Admin/UserSalaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PayID,UserID,Pay")] UserSalary userSalary)
        {
            if (ModelState.IsValid)
            {
                userSalaryRepository.UpdateUserSalary(userSalary);
                userSalaryRepository.Save();
                return RedirectToAction("Index");
            }
            return View(userSalary);
        }

        // GET: Admin/UserSalaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserSalary userSalary = userSalaryRepository.GetUserSalaryById(id.Value);
            if (userSalary == null)
            {
                return HttpNotFound();
            }
            return View(userSalary);
        }

        // POST: Admin/UserSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserSalary userSalary = userSalaryRepository.GetUserSalaryById(id);
            userSalaryRepository.DeleteUserSalary(userSalary);
            userSalaryRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userRepository.Dispose();
                userSalaryRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
