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
    public class ClubToolsListsController : Controller
    {
        private IClubToolsList clubToolsListRepository;

        private ClubContext db = new ClubContext();

        public ClubToolsListsController()
        {
            clubToolsListRepository = new ClubToolsListRepository(db);
        }

        // GET: Admin/ClubToolsLists
        public ActionResult Index()
        {
            return View(clubToolsListRepository.GetAllClubToolsList());
        }

        // GET: Admin/ClubToolsLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubToolsList clubToolsList = db.ClubToolsLists.Find(id);
            if (clubToolsList == null)
            {
                return HttpNotFound();
            }
            return View(clubToolsList);
        }

        // GET: Admin/ClubToolsLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ClubToolsLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ToolsID,ToolsName,CountTools,Spoiled")] ClubToolsList clubToolsList)
        {
            if (ModelState.IsValid)
            {
                clubToolsListRepository.InsertClubToolsList(clubToolsList);
                clubToolsListRepository.Save();
                return RedirectToAction("Index");
            }

            return View(clubToolsList);
        }

        // GET: Admin/ClubToolsLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubToolsList clubToolsList = clubToolsListRepository.GetClubToolsListById(id.Value);
            if (clubToolsList == null)
            {
                return HttpNotFound();
            }
            return View(clubToolsList);
        }

        // POST: Admin/ClubToolsLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ToolsID,ToolsName,CountTools,Spoiled")] ClubToolsList clubToolsList)
        {
            if (ModelState.IsValid)
            {
                clubToolsListRepository.UpdateClubToolsList(clubToolsList);
                clubToolsListRepository.Save();
                return RedirectToAction("Index");
            }
            return View(clubToolsList);
        }

        // GET: Admin/ClubToolsLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubToolsList clubToolsList = clubToolsListRepository.GetClubToolsListById(id.Value);
            if (clubToolsList == null)
            {
                return HttpNotFound();
            }
            return View(clubToolsList);
        }

        // POST: Admin/ClubToolsLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClubToolsList clubToolsList = clubToolsListRepository.GetClubToolsListById(id);
            clubToolsListRepository.DeleteClubToolsList(clubToolsList);
            clubToolsListRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                clubToolsListRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
