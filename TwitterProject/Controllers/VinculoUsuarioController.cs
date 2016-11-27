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
    public class VinculoUsuarioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /VinculoUsuario/
        public ActionResult Index()
        {
            var vinculousuario = db.VinculoUsuario.Include(v => v.Usuario1).Include(v => v.Usuario2);
            return View(vinculousuario.ToList());
        }

        // GET: /VinculoUsuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VinculoUsuario vinculousuario = db.VinculoUsuario.Find(id);
            if (vinculousuario == null)
            {
                return HttpNotFound();
            }
            return View(vinculousuario);
        }

        // GET: /VinculoUsuario/Create
        public ActionResult Create()
        {
            ViewBag.User1ID = new SelectList(db.Users, "Id", "UserName");
            ViewBag.User2ID = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: /VinculoUsuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Ativo,User1ID,User2ID")] VinculoUsuario vinculousuario)
        {
            if (ModelState.IsValid)
            {
                db.VinculoUsuario.Add(vinculousuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User1ID = new SelectList(db.Users, "Id", "UserName", vinculousuario.User1ID);
            ViewBag.User2ID = new SelectList(db.Users, "Id", "UserName", vinculousuario.User2ID);
            return View(vinculousuario);
        }

        // GET: /VinculoUsuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VinculoUsuario vinculousuario = db.VinculoUsuario.Find(id);
            if (vinculousuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.User1ID = new SelectList(db.Users, "Id", "UserName", vinculousuario.User1ID);
            ViewBag.User2ID = new SelectList(db.Users, "Id", "UserName", vinculousuario.User2ID);
            return View(vinculousuario);
        }

        // POST: /VinculoUsuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Ativo,User1ID,User2ID")] VinculoUsuario vinculousuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vinculousuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User1ID = new SelectList(db.Users, "Id", "UserName", vinculousuario.User1ID);
            ViewBag.User2ID = new SelectList(db.Users, "Id", "UserName", vinculousuario.User2ID);
            return View(vinculousuario);
        }

        // GET: /VinculoUsuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VinculoUsuario vinculousuario = db.VinculoUsuario.Find(id);
            if (vinculousuario == null)
            {
                return HttpNotFound();
            }
            return View(vinculousuario);
        }

        // POST: /VinculoUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VinculoUsuario vinculousuario = db.VinculoUsuario.Find(id);
            db.VinculoUsuario.Remove(vinculousuario);
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
