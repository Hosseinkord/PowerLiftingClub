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
    public class CoachPaysController : Controller
    {
        private ICoachPay coachPayRepository;
        private ICoach  coachRepository;
        private ClubContext db = new ClubContext();

        public CoachPaysController()
        {
            coachPayRepository = new CoachPayRepository(db);
            coachRepository = new CoachRepository(db);
        }
        // GET: Admin/CoachPays
        public ActionResult Index()
        {
            return View(coachPayRepository.GetAllCoachPay());
        }

        // GET: Admin/CoachPays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoachPay coachPay = coachPayRepository.GetCoachPayById(id.Value);
            if (coachPay == null)
            {
                return HttpNotFound();
            }
            return View(coachPay);
        }

        // GET: Admin/CoachPays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CoachPays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PayID,CoachID,Pay")] CoachPay coachPay)
        {
            if (ModelState.IsValid)
            {
                coachPayRepository.InsertCoachPay(coachPay);
                coachPayRepository.Save();
                return RedirectToAction("Index");
            }

            return View(coachPay);
        }

        // GET: Admin/CoachPays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoachPay coachPay = coachPayRepository.GetCoachPayById(id.Value);
            if (coachPay == null)
            {
                return HttpNotFound();
            }
            return View(coachPay);
        }

        // POST: Admin/CoachPays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PayID,CoachID,Pay")] CoachPay coachPay)
        {
            if (ModelState.IsValid)
            {
                coachPayRepository.UpdateCoachPay(coachPay);
                coachPayRepository.Save();
                return RedirectToAction("Index");
            }
            return View(coachPay);
        }

        // GET: Admin/CoachPays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoachPay coachPay = coachPayRepository.GetCoachPayById(id.Value);
            if (coachPay == null)
            {
                return HttpNotFound();
            }
            return View(coachPay);
        }

        // POST: Admin/CoachPays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoachPay coachPay = coachPayRepository.GetCoachPayById(id);
            coachPayRepository.DeleteCoachPay(coachPay);
            coachPayRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                coachPayRepository.Dispose();
                coachRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
