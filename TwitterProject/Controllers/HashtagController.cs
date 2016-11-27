using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TwitterProject.Models;

namespace TwitterProject.Controllers
{
    public class HashtagController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Hashtag/
        public ActionResult Index()
        {
            return View(db.Hashtag.ToList());
        }

        // GET: /Hashtag/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hashtag hashtag = db.Hashtag.Find(id);
            if (hashtag == null)
            {
                return HttpNotFound();
            }
            return View(hashtag);
        }

        // GET: /Hashtag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Hashtag/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,texto,PostID")] Hashtag hashtag)
        {
            if (ModelState.IsValid)
            {
                db.Hashtag.Add(hashtag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hashtag);
        }

        // GET: /Hashtag/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hashtag hashtag = db.Hashtag.Find(id);
            if (hashtag == null)
            {
                return HttpNotFound();
            }
            return View(hashtag);
        }

        // POST: /Hashtag/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,texto,PostID")] Hashtag hashtag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hashtag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hashtag);
        }

        // GET: /Hashtag/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hashtag hashtag = db.Hashtag.Find(id);
            if (hashtag == null)
            {
                return HttpNotFound();
            }
            return View(hashtag);
        }

        // POST: /Hashtag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hashtag hashtag = db.Hashtag.Find(id);
            db.Hashtag.Remove(hashtag);
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
