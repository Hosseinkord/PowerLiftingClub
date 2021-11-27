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
    public class CoachesController : Controller
    {
        private ICoach coachRepository;
        private ClubContext db = new ClubContext();

        public CoachesController()
        {
            coachRepository = new CoachRepository(db);
        }

        // GET: Admin/Coaches
        public ActionResult Index()
        {
            return View(coachRepository.GetAllCoach());
        }

        // GET: Admin/Coaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coach coach = coachRepository.GetCoachById(id.Value);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

        // GET: Admin/Coaches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Coaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoachID,Name,Familly,Address,Phone,Preambles,Terms,Age,Grade,ImageName,Type")] Coach coach, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    coach.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/CoachImages/" + coach.ImageName));
                }

                coachRepository.InsertCoach(coach);
                coachRepository.Save();
                return RedirectToAction("Index");
            }

            return View(coach);
        }

        // GET: Admin/Coaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coach coach =coachRepository.GetCoachById(id.Value);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

        // POST: Admin/Coaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CoachID,Name,Familly,Address,Phone,Preambles,Terms,Age,Grade,ImageName,Type")] Coach coach, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    if (coach.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/CoachImages/" + coach.ImageName));
                    }


                    coach.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/CoachImages/" + coach.ImageName));
                }


                coachRepository.UpdateCoach(coach);
                coachRepository.Save();
                return RedirectToAction("Index");
            }
            return View(coach);
        }

        // GET: Admin/Coaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coach coach = coachRepository.GetCoachById(id.Value);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

        // POST: Admin/Coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           var coach = coachRepository.GetCoachById(id);
            if (coach.ImageName!= null)
            {
                System.IO.File.Delete(Server.MapPath("/CoachImages/" + coach.ImageName));
            }
            coachRepository.DeleteCoach(coach);
            coachRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                coachRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
