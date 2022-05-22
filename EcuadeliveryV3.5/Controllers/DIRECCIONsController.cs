using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcuadeliveryV3._5;

namespace EcuadeliveryV3._5.Controllers
{
    public class DIRECCIONsController : Controller
    {
        private BD_EcuaDeliveryEntities db = new BD_EcuaDeliveryEntities();

        // GET: DIRECCIONs
        public ActionResult Index()
        {
            var dIRECCION = db.DIRECCION.Include(d => d.CIUDAD).Include(d => d.USUARIO);
            return View(dIRECCION.ToList());
        }

        // GET: DIRECCIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECCION dIRECCION = db.DIRECCION.Find(id);
            if (dIRECCION == null)
            {
                return HttpNotFound();
            }
            return View(dIRECCION);
        }

        // GET: DIRECCIONs/Create
        public ActionResult Create()
        {
            ViewBag.CIU_ID = new SelectList(db.CIUDAD, "CIU_ID", "CIU_NOMBRE");
            ViewBag.USU_ID = new SelectList(db.USUARIO, "USU_ID", "USU_NOMBRE");
            return View();
        }

        // POST: DIRECCIONs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DIR_ID,USU_ID,CIU_ID,DIR_CALLE_P,DIR_CALLE_S,DIR_NUM_C,DIR_DETALLE")] DIRECCION dIRECCION)
        {
            if (ModelState.IsValid)
            {
                db.DIRECCION.Add(dIRECCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CIU_ID = new SelectList(db.CIUDAD, "CIU_ID", "CIU_NOMBRE", dIRECCION.CIU_ID);
            ViewBag.USU_ID = new SelectList(db.USUARIO, "USU_ID", "USU_NOMBRE", dIRECCION.USU_ID);
            return View(dIRECCION);
        }

        // GET: DIRECCIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECCION dIRECCION = db.DIRECCION.Find(id);
            if (dIRECCION == null)
            {
                return HttpNotFound();
            }
            ViewBag.CIU_ID = new SelectList(db.CIUDAD, "CIU_ID", "CIU_NOMBRE", dIRECCION.CIU_ID);
            ViewBag.USU_ID = new SelectList(db.USUARIO, "USU_ID", "USU_NOMBRE", dIRECCION.USU_ID);
            return View(dIRECCION);
        }

        // POST: DIRECCIONs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DIR_ID,USU_ID,CIU_ID,DIR_CALLE_P,DIR_CALLE_S,DIR_NUM_C,DIR_DETALLE")] DIRECCION dIRECCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dIRECCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CIU_ID = new SelectList(db.CIUDAD, "CIU_ID", "CIU_NOMBRE", dIRECCION.CIU_ID);
            ViewBag.USU_ID = new SelectList(db.USUARIO, "USU_ID", "USU_NOMBRE", dIRECCION.USU_ID);
            return View(dIRECCION);
        }

        // GET: DIRECCIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECCION dIRECCION = db.DIRECCION.Find(id);
            if (dIRECCION == null)
            {
                return HttpNotFound();
            }
            return View(dIRECCION);
        }

        // POST: DIRECCIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DIRECCION dIRECCION = db.DIRECCION.Find(id);
            db.DIRECCION.Remove(dIRECCION);
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
