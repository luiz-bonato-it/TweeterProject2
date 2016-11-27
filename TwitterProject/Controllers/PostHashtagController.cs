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
    public class PostHashtagController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /PostHashtag/
        public ActionResult Index()
        {
            var posthashtag = db.PostHashtag.Include(p => p.Hashtags).Include(p => p.Posts);
            return View(posthashtag.ToList());
        }

        // GET: /PostHashtag/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostHashtag posthashtag = db.PostHashtag.Find(id);
            if (posthashtag == null)
            {
                return HttpNotFound();
            }
            return View(posthashtag);
        }

        // GET: /PostHashtag/Create
        public ActionResult Create()
        {
            ViewBag.HashtagID = new SelectList(db.Hashtag, "ID", "texto");
            ViewBag.PostID = new SelectList(db.Post, "ID", "Texto");
            return View();
        }

        // POST: /PostHashtag/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,PostID,HashtagID")] PostHashtag posthashtag)
        {
            if (ModelState.IsValid)
            {
                db.PostHashtag.Add(posthashtag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HashtagID = new SelectList(db.Hashtag, "ID", "texto", posthashtag.HashtagID);
            ViewBag.PostID = new SelectList(db.Post, "ID", "Texto", posthashtag.PostID);
            return View(posthashtag);
        }

        // GET: /PostHashtag/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostHashtag posthashtag = db.PostHashtag.Find(id);
            if (posthashtag == null)
            {
                return HttpNotFound();
            }
            ViewBag.HashtagID = new SelectList(db.Hashtag, "ID", "texto", posthashtag.HashtagID);
            ViewBag.PostID = new SelectList(db.Post, "ID", "Texto", posthashtag.PostID);
            return View(posthashtag);
        }

        // POST: /PostHashtag/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,PostID,HashtagID")] PostHashtag posthashtag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posthashtag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HashtagID = new SelectList(db.Hashtag, "ID", "texto", posthashtag.HashtagID);
            ViewBag.PostID = new SelectList(db.Post, "ID", "Texto", posthashtag.PostID);
            return View(posthashtag);
        }

        // GET: /PostHashtag/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostHashtag posthashtag = db.PostHashtag.Find(id);
            if (posthashtag == null)
            {
                return HttpNotFound();
            }
            return View(posthashtag);
        }

        // POST: /PostHashtag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostHashtag posthashtag = db.PostHashtag.Find(id);
            db.PostHashtag.Remove(posthashtag);
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
