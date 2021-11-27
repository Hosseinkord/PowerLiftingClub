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
    public class Cal_EndController : Controller
    {
        private ICal_EndRepository cal_endRepository;
        private IEnterRepository enterRepository;
        private IMasterRepository masterRepository;
        private IHelp2Repository help2Repository;
        private IHelpRepository helpRepository;
        private IDateRepository dateRepository;
        private IMasterDateRepository masterdateRepository;
        private IMasterLessonRepository masterlessonRepository;
        private ILessonRepository lessonRepository;

        Pr_UniContext db = new Pr_UniContext();
        public Cal_EndController()
        {
            cal_endRepository = new Cal_EndRepository(db);
            enterRepository = new EnterRepository(db);
            masterRepository = new MasterRepository(db);
            help2Repository = new Help2Repository(db);
            helpRepository = new HelpRepository(db);
            masterdateRepository = new MasterDateRepository(db);
            masterlessonRepository = new MasterLessonRepository(db);
            dateRepository = new DateRepository(db);
            lessonRepository = new LessonRepository(db);
        }
        // GET: Admin1/Cal_End
        public ActionResult Index()
        {
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Lesson = lessonRepository.GetAllLessons();
            ViewBag.ClaEnd = cal_endRepository.GetAllCal_Ends();
            ViewBag.Date = dateRepository.GetAllDates();
            return View(cal_endRepository.GetAllCal_Ends());
        }

        // GET: Admin1/Cal_End/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cal_End cal_End = db.Cal_Ends.Find(id);
            if (cal_End == null)
            {
                return HttpNotFound();
            }
            return View(cal_End);
        }

        // GET: Admin1/Cal_End/Create
        public ActionResult Create()
        {
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Lesson = lessonRepository.GetAllLessons();
            ViewBag.ClaEnd = cal_endRepository.GetAllCal_Ends();
            ViewBag.Date = dateRepository.GetAllDates();
            return View();
        }

        // POST: Admin1/Cal_End/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cal_EndId,Time,Master,Lesson,Number")] Cal_End cal_End)
        {
            ViewBag.Master = masterRepository.GetAllMasters();
            ViewBag.Lesson = lessonRepository.GetAllLessons();
            ViewBag.ClaEnd = cal_endRepository.GetAllCal_Ends();
            ViewBag.Date = dateRepository.GetAllDates(); 

            int j = 1;
            int i = 0;
            int h = 0;
            int Mas = 0;
            int Term1 = 0;

            int[] MD1 = new int[400];
            int[] MD2 = new int[400];
            int[] MD3 = new int[400];
            int[] MD4 = new int[400];
            int[] MD5 = new int[2000];
            for (int k = 0;  k < 200;  k++)
            {
                cal_End.Lesson = 0;
                cal_End.Master = 0;
                cal_End.Number = 0;
                cal_End.Time = 0;
                cal_endRepository.InsertCal_End(cal_End);
                cal_endRepository.save();
            }


            foreach (var D in dateRepository.GetAllDates())
            {
                j = 1;
                foreach (var Hel in help2Repository.GetAllHelp2s().OrderBy(c=>c.ScHelp))
                {
                    if(D.DateId == Hel.DateId && Hel.MasterCode != Mas)
                    {
                        MD1[i] = D.DateId;
                        MD2[i] = Hel.MasterCode;
                        MD3[i] = Hel.LessonCode;
                        MD4[i] = j;
                        Mas = Hel.MasterCode;
                        j++;
                        i++;
                    }
                    
                }
            }



            foreach (var cal in cal_endRepository.GetAllCal_Ends())
            {
                cal.Time = MD1[h];
                cal.Lesson = MD3[h];
                cal.Master = MD2[h];
                cal.Number = MD4[h];
                h++;
            }

            if (ModelState.IsValid)
            {
                cal_endRepository.save();
                return RedirectToAction("Index");
            }

            return View(cal_End);
        }

        // GET: Admin1/Cal_End/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cal_End cal_End = db.Cal_Ends.Find(id);
            if (cal_End == null)
            {
                return HttpNotFound();
            }
            return View(cal_End);
        }

        // POST: Admin1/Cal_End/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cal_EndId,Time,Master,Lesson,Number")] Cal_End cal_End)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cal_End).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cal_End);
        }

        // GET: Admin1/Cal_End/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cal_End cal_End = db.Cal_Ends.Find(id);
            if (cal_End == null)
            {
                return HttpNotFound();
            }
            return View(cal_End);
        }

        // POST: Admin1/Cal_End/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cal_End cal_End = db.Cal_Ends.Find(id);
            db.Cal_Ends.Remove(cal_End);
            db.SaveChanges();
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
