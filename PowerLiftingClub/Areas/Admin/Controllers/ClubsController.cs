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
    public class ClubsController: Controller
    {
        private IClub clubRepository;
        private ClubContext db = new ClubContext();


        public ClubsController()
        {
            clubRepository = new ClubRepository(db);
        }

        // GET: Admin/Clubs
        public ActionResult Index()
        {
            return View(clubRepository.GetAllClub());
        }

        // GET: Admin/Clubs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Clubs.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // GET: Admin/Clubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClubID,Name,ManagerName,Address,Phone,Time")] Club club)
        {
            if (ModelState.IsValid)
            {
                clubRepository.InsertClub(club);
                clubRepository.Save();
                return RedirectToAction("Index");
            }

            return View(club);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = clubRepository.GetClubById(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClubID,Name,ManagerName,Address,Phone,Time")] Club club, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                clubRepository.UpdateClub(club);
                clubRepository.Save();
                return RedirectToAction("Index");
            }
            return View(club);
        }

        // GET: Admin/Clubs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = clubRepository.GetClubById(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // POST: Admin/Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var club = clubRepository.GetClubById(id);
            clubRepository.DeleteClub(club);
            clubRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                clubRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
