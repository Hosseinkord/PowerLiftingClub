using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Project_Uni.Areas.Admin1.Controllers
{
    public class LessonsController : Controller
    {
        private IMasterLessonRepository masterlessonRepository;
        private ILessonRepository lessonRepository;
        Pr_UniContext db = new Pr_UniContext();
        public LessonsController()
        {
            masterlessonRepository = new MasterLessonRepository(db);
            lessonRepository = new LessonRepository(db);
        }

        // GET: Admin1/Lessons
        public ActionResult Index()
        {
            return View(lessonRepository.GetAllLessons());
        }

        // GET: Admin1/Lessons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = lessonRepository.GetLessonById(id.Value);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // GET: Admin1/Lessons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin1/Lessons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LessonId,LessonCode,LessonGroup,LessonName,Unit,Term,Score")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                lessonRepository.InsertLesson(lesson);
                lessonRepository.save();
                return RedirectToAction("Index");
            }

            return View(lesson);
        }

        // GET: Admin1/Lessons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = lessonRepository.GetLessonById(id.Value);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // POST: Admin1/Lessons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LessonId,LessonCode,LessonGroup,LessonName,Unit,Term,Score")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                lessonRepository.UpdateLesson(lesson);
                lessonRepository.save();
                return RedirectToAction("Index");
            }
            return View(lesson);
        }

        // GET: Admin1/Lessons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = lessonRepository.GetLessonById(id.Value);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // POST: Admin1/Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int lc = 0;
            foreach (var hp in lessonRepository.GetAllLessons())
            {
                if (hp.LessonId == id)
                {
                    lc = hp.LessonCode;
                }
            }
            foreach (var MasterDate in masterlessonRepository.GetAllMasterLessons())
            {
                if (MasterDate.LessonCode == lc)
                {
                    masterlessonRepository.DeleteMasterLesson(MasterDate);
                }
            }


            lessonRepository.DeleteLesson(id);
            lessonRepository.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                lessonRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
