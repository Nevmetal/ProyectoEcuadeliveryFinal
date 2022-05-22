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
    [Authorize]
    public class PRODUCTOController : Controller
    {
        private BD_EcuaDeliveryEntities db = new BD_EcuaDeliveryEntities();

        // GET: PRODUCTO
        public ActionResult Index()
        {
            PROVEEDOR userp = new PROVEEDOR();
            userp.PRV_ID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ID"].ToString());
            var tbl_Producto = db.PRODUCTOS.Where(a => a.PRV_ID.Equals(userp.PRV_ID)).ToList();
            //var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA).Include(p => p.PROVEEDOR);
            return View(tbl_Producto);
        }
        public ActionResult Index1()
        {
            var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA).Include(p => p.PROVEEDOR);
            return View(pRODUCTOS.ToList());
        }

        // GET: PRODUCTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTOS);
        }

        // GET: PRODUCTO/Create
        public ActionResult Create()
        {
            ViewBag.CAT_ID = new SelectList(db.CATEGORIA, "CAT_ID", "CAT_NOMBRE");
            ViewBag.PRV_ID = new SelectList(db.PROVEEDOR, "PRV_ID", "PRV_NOMBRE");
            //PROVEEDOR userp = new PROVEEDOR();
            //userp.PRV_ID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ID"].ToString());
           // ViewBag.PRV_IDs = Convert.ToInt32(System.Web.HttpContext.Current.Session["ID"].ToString()); 
            return View();
        }

        // POST: PRODUCTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRO_NOM,PRO_PRECIO,PRO_DESCRIPCION,PRO_STOCK,PRO_FECHA_IN,PRO_ID,CAT_ID,PRV_ID,PRO_IMG")] PRODUCTOS pRODUCTOS)
        {
            pRODUCTOS.PRV_ID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ID"].ToString());
            if (ModelState.IsValid)
            {
                db.PRODUCTOS.Add(pRODUCTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CAT_ID = new SelectList(db.CATEGORIA, "CAT_ID", "CAT_NOMBRE", pRODUCTOS.CAT_ID);
            ViewBag.PRV_ID = new SelectList(db.PROVEEDOR, "PRV_ID", "PRV_NOMBRE", pRODUCTOS.PRV_ID);
            return View(pRODUCTOS);
        }

        // GET: PRODUCTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.CAT_ID = new SelectList(db.CATEGORIA, "CAT_ID", "CAT_NOMBRE", pRODUCTOS.CAT_ID);
            ViewBag.PRV_ID = new SelectList(db.PROVEEDOR, "PRV_ID", "PRV_NOMBRE", pRODUCTOS.PRV_ID);
            return View(pRODUCTOS);
        }

        // POST: PRODUCTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRO_NOM,PRO_PRECIO,PRO_DESCRIPCION,PRO_STOCK,PRO_FECHA_IN,PRO_ID,CAT_ID,PRV_ID,PRO_IMG")] PRODUCTOS pRODUCTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CAT_ID = new SelectList(db.CATEGORIA, "CAT_ID", "CAT_NOMBRE", pRODUCTOS.CAT_ID);
            ViewBag.PRV_ID = new SelectList(db.PROVEEDOR, "PRV_ID", "PRV_NOMBRE", pRODUCTOS.PRV_ID);
            return View(pRODUCTOS);
        }

        // GET: PRODUCTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTOS);
        }

        // POST: PRODUCTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            db.PRODUCTOS.Remove(pRODUCTOS);
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
