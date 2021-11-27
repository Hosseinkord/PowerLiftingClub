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
    public class MastersController : Controller
    {
        private IMasterRepository masterRepository;
        private IMasterDateRepository masterdateRepository;
        Pr_UniContext db = new Pr_UniContext();
        public MastersController()
        {
            masterdateRepository = new MasterDateRepository(db);
            masterRepository = new MasterRepository(db);
        }

        // GET: Admin1/Masterس
        public ActionResult Index()
        {
            return View(masterRepository.GetAllMasters());
        }

        // GET: Admin1/Masters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = masterRepository.GetMasterById(id.Value);
            if (master == null)
            {
                return HttpNotFound();
            }
            return View(master);
        }

        // GET: Admin1/masters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin1/masters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MasterId,MasterCode,MasterName,NumLesson")] Master master)
        {
            if (ModelState.IsValid)
            {
                MasterDate md = new MasterDate();
                for (int i= 1;i< 26;i++)
                {
                    md.DateId = i;
                    md.MasterCode = master.MasterCode;
                    md.Status = 0;
                    masterdateRepository.InsertMasterDate(md);
                    masterdateRepository.save();
                }
                masterRepository.InsertMaster(master);
                masterRepository.save();
                return RedirectToAction("Index");
            }
            return View(master);
        }

        // GET: Admin1/masters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = masterRepository.GetMasterById(id.Value);
            if (master == null)
            {
                return HttpNotFound();
            }
            return View(master);
        }

        // POST: Admin1/masters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MasterId,MasterCode,MasterName,NumLesson")] Master master)
        {
            if (ModelState.IsValid)
            {
                masterRepository.UpdateMaster(master);
                masterRepository.save();
                return RedirectToAction("Index");
            }
            return View(master);
        }

        // GET: Admin1/masters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = masterRepository.GetMasterById(id.Value);
            if (master == null)
            {
                return HttpNotFound();
            }
            return View(master);
        }

        // POST: Admin1/masters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int mc = 0;
            foreach (var hp in masterRepository.GetAllMasters())
            {
                if (hp.MasterId == id)
                {
                    mc = hp.MasterCode;
                }
            }
            foreach (var MasterDate in masterdateRepository.GetAllMasterDates())
            {
                if (MasterDate.MasterCode == mc)
                {
                    masterdateRepository.DeleteMasterDate(MasterDate);
                }
            }



            masterRepository.DeleteMaster(id);
            masterRepository.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                masterRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
