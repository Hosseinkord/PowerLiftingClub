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
    public class HelpsController : Controller
    {
        private IEnterRepository enterRepository;
        private IMasterRepository masterRepository;
        private IHelp2Repository help2Repository;
        private IHelpRepository helpRepository;
        private IDateRepository dateRepository;
        private IMasterDateRepository masterdateRepository;
        private IMasterLessonRepository masterlessonRepository;

        Pr_UniContext db = new Pr_UniContext();
        public HelpsController()
        {
            enterRepository = new EnterRepository(db);
            help2Repository = new Help2Repository(db);
            helpRepository = new HelpRepository(db);
            masterdateRepository = new MasterDateRepository(db);
            masterlessonRepository = new MasterLessonRepository(db);
            dateRepository = new DateRepository(db);
            masterRepository = new MasterRepository(db);
        }

        // GET: Admin1/Helps
        public ActionResult Index()
        {
            return View(helpRepository.GetAllHelps());
        }

        // GET: Admin1/Helps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Help help = db.Helps.Find(id);
            if (help == null)
            {
                return HttpNotFound();
            }
            return View(help);
        }

        // GET: Admin1/Helps/Create
        public ActionResult Create()
        {
            ViewBag.Enter = enterRepository.GetAllEnters();
            ViewBag.Date = dateRepository.GetAllDates();
            ViewBag.MasterDate = masterdateRepository.GetAllMasterDates();
            ViewBag.MasterLesson = masterlessonRepository.GetAllMasterLessons();
            ViewBag.Help = helpRepository.GetAllHelps();
            ViewBag.Help2 = help2Repository.GetAllHelp2s();
            ViewBag.Master = masterRepository.GetAllMasters();
            return View();
        }

        // POST: Admin1/Helps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassId,DI,MC")] Help help)
        {
            int[] MD1 = new int[200];
            int[] MD2 = new int[200];
            int[] MD3 = new int[200];

            for (int k = 0; k < 200; k++)
            {
                help.DI = 0;
                help.MC = 0;
                help.ST = 0;
                helpRepository.InsertHelp(help);
                helpRepository.save();
            }


            int i = 0;
            int j = 0;


            foreach (var Date in dateRepository.GetAllDates())
            {
                foreach (var MasterDate in masterdateRepository.GetAllMasterDates())
                {
                    if ((Date.DateId == MasterDate.DateId) && MasterDate.Status != -1)
                    {
                        MD1[i] = MasterDate.DateId;
                        MD2[i] = MasterDate.MasterCode;
                        MD3[i] = MasterDate.Status;
                        i++;
                    }
                }
            }

            foreach (var Help in helpRepository.GetAllHelps())
            {
                if (j < i)
                {
                    Help.DI = MD1[j];
                    Help.MC = MD2[j];
                    Help.ST = MD3[j];
                    j++;
                }
                else
                {
                    helpRepository.DeleteHelp(Help.ClassId);
                }
            }

            if (ModelState.IsValid)
            {
                helpRepository.save();
                return RedirectToAction("Create");
            }
            
            return View(help);

        }

        // GET: Admin1/Helps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Help help = db.Helps.Find(id);
            if (help == null)
            {
                return HttpNotFound();
            }
            return View(help);
        }

        // POST: Admin1/Helps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassId,DI,MC")] Help help)
        {
            if (ModelState.IsValid)
            {
                db.Entry(help).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(help);
        }

        // GET: Admin1/Helps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Help help = helpRepository.GetHelpById(id.Value);
            if (help == null)
            {
                return HttpNotFound();
            }
            return View(help);
        }

        // POST: Admin1/Helps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           

            Help help = helpRepository.GetHelpById(id);
            helpRepository.DeleteHelp(help);
            helpRepository.save();
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
