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
    public class UsersController : Controller
    {
        private IUser userRepository;
        private ClubContext db = new ClubContext();

        public UsersController()
        {
            userRepository = new UserRepository(db);
        }
        // GET: Admin/Users
        public ActionResult Index()
        {
            return View(userRepository.GetAllUser());
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userRepository.GetUserById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Name,Familly,Address,Phone,Preambles,Terms,Age,ImageName,Type")] User user, HttpPostedFileBase imgUpUs)
        {
            if (ModelState.IsValid)
            {
                if (imgUpUs != null)
                {
                    user.ImageName = Guid.NewGuid() + Path.GetExtension(imgUpUs.FileName);
                    imgUpUs.SaveAs(Server.MapPath("/UserImages/" + user.ImageName));
                }
                userRepository.InsertUser(user);
                userRepository.Save();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userRepository.GetUserById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Name,Familly,Address,Phone,Preambles,Terms,Age,ImageName,Type")] User user, HttpPostedFileBase imgUpUs)
        {
            if (ModelState.IsValid)
            {
                if (imgUpUs != null)
                {
                    if (user.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/UserImages/" + user.ImageName));
                    }


                    user.ImageName = Guid.NewGuid() + Path.GetExtension(imgUpUs.FileName);
                    imgUpUs.SaveAs(Server.MapPath("/UserImages/" + user.ImageName));
                }
                userRepository.UpdateUser(user);
                userRepository.Save();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userRepository.GetUserById(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = userRepository.GetUserById(id);
            if (user.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/UserImages/" + user.ImageName));
            }
            userRepository.DeleteUser(user);
            userRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
