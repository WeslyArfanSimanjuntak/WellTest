using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WellTest.Models;

namespace WellTest.Controllers
{
    public class WellTestController : Controller
    {
        private WellTestEntities db = new WellTestEntities();

        // GET: WellTest
        public ActionResult Index()
        {
            var wellTest = db.WellTest.Include(w => w.Well);
            return View(wellTest.ToList());
        }

        // GET: WellTest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.WellTest wellTest = db.WellTest.Find(id);
            if (wellTest == null)
            {
                return HttpNotFound();
            }
            return View(wellTest);
        }

        // GET: WellTest/Create
        public ActionResult Create()
        {
            ViewBag.WELLID = new SelectList(db.Well, "WELLID", "ADDRESS");
            return View();
        }

        // POST: WellTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,WELLID,DATE,TIMESTART,TIMESTOP,BEAN,CREATEDBY,CREATEDDATE,UPDATEDBY,UPDATEDDATE")] Models.WellTest wellTest)
        {
            if (ModelState.IsValid)
            {
                db.WellTest.Add(wellTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WELLID = new SelectList(db.Well, "WELLID", "ADDRESS", wellTest.WELLID);
            return View(wellTest);
        }

        // GET: WellTest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.WellTest wellTest = db.WellTest.Find(id);
            if (wellTest == null)
            {
                return HttpNotFound();
            }
            ViewBag.WELLID = new SelectList(db.Well, "WELLID", "WELLID", wellTest.WELLID);
            return View(wellTest);
        }

        // POST: WellTest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,WELLID,DATE,TIMESTART,TIMESTOP,BEAN,CREATEDBY,CREATEDDATE,UPDATEDBY,UPDATEDDATE")] Models.WellTest wellTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wellTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WELLID = new SelectList(db.Well, "WELLID", "ADDRESS", wellTest.WELLID);
            return View(wellTest);
        }

        // GET: WellTest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.WellTest wellTest = db.WellTest.Find(id);
            if (wellTest == null)
            {
                return HttpNotFound();
            }
            return View(wellTest);
        }

        // POST: WellTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.WellTest wellTest = db.WellTest.Find(id);
            db.WellTest.Remove(wellTest);
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
