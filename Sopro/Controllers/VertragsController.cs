using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sopro.Models;

namespace Sopro.Controllers
{
    public class VertragsController : Controller
    {
        private SoproDBEntities db = new SoproDBEntities();


        //GET: Home

        public ActionResult Home()
        {
            return View();
        }
        
        // GET: Vertrags
        public ActionResult Overview()
        {
            return View(db.Vertrags.ToList());
        }

        // GET: Vertrags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vertrag vertrag = db.Vertrags.Find(id);
            if (vertrag == null)
            {
                return HttpNotFound();
            }
            return View(vertrag);
        }

        // GET: Vertrags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vertrags/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Typ,Typ_2,Datum,Beginn,Ende")] Vertrag vertrag)
        {
            if (ModelState.IsValid)
            {
                db.Vertrags.Add(vertrag);
                db.SaveChanges();
                return RedirectToAction("Overview");
            }

            return View(vertrag);
        }

        // GET: Vertrags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vertrag vertrag = db.Vertrags.Find(id);
            if (vertrag == null)
            {
                return HttpNotFound();
            }
            return View(vertrag);
        }

        // POST: Vertrags/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Typ,Typ_2,Datum,Beginn,Ende")] Vertrag vertrag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vertrag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Overview");
            }
            return View(vertrag);
        }

        // GET: Vertrags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vertrag vertrag = db.Vertrags.Find(id);
            if (vertrag == null)
            {
                return HttpNotFound();
            }
            return View(vertrag);
        }

        // POST: Vertrags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vertrag vertrag = db.Vertrags.Find(id);
            db.Vertrags.Remove(vertrag);
            db.SaveChanges();
            return RedirectToAction("Overview");
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
