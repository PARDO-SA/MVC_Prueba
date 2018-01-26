using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Prueba.Models.Clases;

namespace MVC_Prueba.Controllers
{
    public class ComisionesBPController : Controller
    {
        private CentralDBContext db = new CentralDBContext();

        // GET: ComisionesBP
        public ActionResult Index()
        {
            return View(db.ComisionesBPs.ToList());
        }

        // GET: ComisionesBP/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComisionesBP comisionesBP = db.ComisionesBPs.Find(id);
            if (comisionesBP == null)
            {
                return HttpNotFound();
            }
            return View(comisionesBP);
        }

        // GET: ComisionesBP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComisionesBP/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodSuc,CodVen,Recibo,Comprobante,Cuota,CodArt,Vendedor,FechaRec,ImporteRec,CodCli,DesArt,Porcentaje,ImporteArt,ComisionVen,ComisionSuc,Periodo")] ComisionesBP comisionesBP)
        {
            if (ModelState.IsValid)
            {
                db.ComisionesBPs.Add(comisionesBP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comisionesBP);
        }

        // GET: ComisionesBP/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComisionesBP comisionesBP = db.ComisionesBPs.Find(id);
            if (comisionesBP == null)
            {
                return HttpNotFound();
            }
            return View(comisionesBP);
        }

        // POST: ComisionesBP/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodSuc,CodVen,Recibo,Comprobante,Cuota,CodArt,Vendedor,FechaRec,ImporteRec,CodCli,DesArt,Porcentaje,ImporteArt,ComisionVen,ComisionSuc,Periodo")] ComisionesBP comisionesBP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comisionesBP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comisionesBP);
        }

        // GET: ComisionesBP/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComisionesBP comisionesBP = db.ComisionesBPs.Find(id);
            if (comisionesBP == null)
            {
                return HttpNotFound();
            }
            return View(comisionesBP);
        }

        // POST: ComisionesBP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ComisionesBP comisionesBP = db.ComisionesBPs.Find(id);
            db.ComisionesBPs.Remove(comisionesBP);
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
