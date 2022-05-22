using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using EcuadeliveryV3._5;
using EcuadeliveryV3._5.Models;

namespace EcuaDeliveryV3.Controllers
{
    
    [Authorize]
    public class PRODUCTOClienteController : Controller
    {
        private BD_EcuaDeliveryEntities db = new BD_EcuaDeliveryEntities();

        // GET: PRODUCTOCliente
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult QuienesSomos()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            return View();
        }
        public ActionResult Index1()
        {
            
            var tbl_Producto = db.PRODUCTOS.Where(a => a.CAT_ID.Equals(1)).ToList();
            //var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA).Include(p => p.PROVEEDOR);
            return View(tbl_Producto);
        }
        public ActionResult Index2()
        {

            var tbl_Producto = db.PRODUCTOS.Where(a => a.CAT_ID.Equals(2)).ToList();
            //var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA).Include(p => p.PROVEEDOR);
            return View(tbl_Producto);
        }
        public ActionResult Index3()
        {

            var tbl_Producto = db.PRODUCTOS.Where(a => a.CAT_ID.Equals(3)).ToList();
            //var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA).Include(p => p.PROVEEDOR);
            return View(tbl_Producto);
        }
        public ActionResult Index4()
        {

            var tbl_Producto = db.PRODUCTOS.Where(a => a.CAT_ID.Equals(4)).ToList();
            //var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA).Include(p => p.PROVEEDOR);
            return View(tbl_Producto);
        }
        public ActionResult Index5()
        {

            var tbl_Producto = db.PRODUCTOS.Where(a => a.CAT_ID.Equals(5)).ToList();
            //var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA).Include(p => p.PROVEEDOR);
            return View(tbl_Producto);
        }
        public ActionResult Index6()
        {

            var tbl_Producto = db.PRODUCTOS.Where(a => a.CAT_ID.Equals(6)).ToList();
            //var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA).Include(p => p.PROVEEDOR);
            return View(tbl_Producto);
        }
        public ActionResult Index7()
        {

            var tbl_Producto = db.PRODUCTOS.Where(a => a.CAT_ID.Equals(7)).ToList();
            //var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA).Include(p => p.PROVEEDOR);
            return View(tbl_Producto);
        }
        public ActionResult Index8()
        {

            var tbl_Producto = db.PRODUCTOS.Where(a => a.CAT_ID.Equals(8)).ToList();
            //var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA).Include(p => p.PROVEEDOR);
            return View(tbl_Producto);
        }
        public ActionResult Index9()
        {

            var tbl_Producto = db.PRODUCTOS.Where(a => a.CAT_ID.Equals(9)).ToList();
            //var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA).Include(p => p.PROVEEDOR);
            return View(tbl_Producto);
        }
        public ActionResult Index10()
        {

            var tbl_Producto = db.PRODUCTOS.Where(a => a.CAT_ID.Equals(10)).ToList();
            //var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA).Include(p => p.PROVEEDOR);
            return View(tbl_Producto);
        }
        public ActionResult Index11()
        {

            var tbl_Producto = db.PRODUCTOS.Where(a => a.CAT_ID.Equals(11)).ToList();
            //var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA).Include(p => p.PROVEEDOR);
            return View(tbl_Producto);
        }

        public ActionResult Pago()
        {
            var id = System.Web.HttpContext.Current.Session["ID"].ToString();
            int idd = Convert.ToInt32(id);
            var dir = db.DIRECCION.Where(a => a.USU_ID.Equals(idd)).ToList();
            var ci = db.CIUDAD;
            DIRECCION dIRECCION = new DIRECCION();
            List<SelectListItem> items = dir.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.DIR_CALLE_P.ToString(),
                    Value = d.DIR_ID.ToString(),
                    Selected = false

                };
            });
            ViewBag.items = items;
            ViewBag.CIU_ID = new SelectList(db.CIUDAD, "CIU_ID", "CIU_NOMBRE");
            ViewBag.USU_ID = new SelectList(db.USUARIO, "USU_ID", "USU_NOMBRE");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(Convert.ToInt32(id));
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            Tuple<USUARIO, IEnumerable<EcuadeliveryV3._5.DIRECCION>, DIRECCION> Model = new Tuple<USUARIO, IEnumerable<EcuadeliveryV3._5.DIRECCION>, DIRECCION>(uSUARIO, dir, dIRECCION);
            //Tuple<USUARIO, IEnumerable<EcuadeliveryV3._5.DIRECCION>> Model = new Tuple<USUARIO, IEnumerable<EcuadeliveryV3._5.DIRECCION>>(uSUARIO, dir);
            return View(Model);
            
            
            
        }
        // GET: PRODUCTOCliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTO = db.PRODUCTOS.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // GET: PRODUCTOCliente/Create
        public ActionResult Create()
        {
            ViewBag.CAT_ID = new SelectList(db.CATEGORIA, "CAT_ID", "CAT_NOMBRE");
            ViewBag.PRV_ID = new SelectList(db.PROVEEDOR, "PRV_ID", "PRV_NOMBRE");
            return View();
        }
        [HttpPost]
        public ActionResult Pago(int CIU_ID, string Callep, string Calles, string Numberocasa, string Detalle,string Tar, string Fecadu,string CVC, string imgs, string cant, modelp model)
        {
            BD_EcuaDeliveryEntities db = new BD_EcuaDeliveryEntities();
            string[] ids = Request.Form.GetValues("imgs");
            string[] can = Request.Form.GetValues("cant");
            var id = System.Web.HttpContext.Current.Session["ID"].ToString();
            var idC = Convert.ToInt32(id);
            //crear y llenar factura
            using (db)
            {
                //crear Factura
                db.CrearFactura(idC);

                //Llenar detalle
                for (int i = 0; i < ids.Length; i++)
                {
                    int idsI, canI;
                    idsI = int.Parse(ids[i]);
                    canI = int.Parse(can[i]);
                    db.LlenarDetalle(idsI, canI);
                }
                //PRODUCTOS pro = db.PRODUCTOS.Find(Convert.ToInt32(imgs));
                //var pro = db.PRODUCTOS.Where(a => a.PRO_IMG.Equals(imgs)).ToList();
                DIRECCION usdir = new DIRECCION();
                usdir.USU_ID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ID"].ToString());
                usdir.CIU_ID = CIU_ID;
                usdir.DIR_CALLE_P = Callep;
                usdir.DIR_CALLE_S = Calles;
                usdir.DIR_NUM_C = Numberocasa;
                usdir.DIR_DETALLE = Detalle;
                if (ModelState.IsValid)
                {


                    if (Callep != " ")
                    {
                        db.DIRECCION.Add(usdir);
                        db.SaveChanges();
                    }
                    //db.DIRECCION.Add(usdir);
                    //db.SaveChanges();
                    //ViewBag.CIU_ID = new SelectList(db.CIUDAD, "CIU_ID", "CIU_NOMBRE", usdir.CIU_ID);
                    //ViewBag.USU_ID = new SelectList(db.USUARIO, "USU_ID", "USU_NOMBRE", usdir.USU_ID);
                   

                    return RedirectToAction("Index", new { message = "Es necesario llenar los campos para realizar el login!" });
                }
                else
                {
                    ViewBag.CIU_ID = new SelectList(db.CIUDAD, "CIU_ID", "CIU_NOMBRE", usdir.CIU_ID);
                    ViewBag.USU_ID = new SelectList(db.USUARIO, "USU_ID", "USU_NOMBRE", usdir.USU_ID);
                    return View(usdir);
                }
            }

           

           
        }

        // POST: PRODUCTOCliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRO_NOM,PRO_PRECIO,PRO_DESCRIPCION,PRO_STOCK,PRO_FECHA_IN,PRO_ID,CAT_ID,PRV_ID,PRO_IMG")] PRODUCTOS pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTOS.Add(pRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CAT_ID = new SelectList(db.CATEGORIA, "CAT_ID", "CAT_NOMBRE", pRODUCTO.CAT_ID);
            ViewBag.PRV_ID = new SelectList(db.PROVEEDOR, "PRV_ID", "PRV_NOMBRE", pRODUCTO.PRV_ID);
            return View(pRODUCTO);
        }

        // GET: PRODUCTOCliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTO = db.PRODUCTOS.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CAT_ID = new SelectList(db.CATEGORIA, "CAT_ID", "CAT_NOMBRE", pRODUCTO.CAT_ID);
            ViewBag.PRV_ID = new SelectList(db.PROVEEDOR, "PRV_ID", "PRV_NOMBRE", pRODUCTO.PRV_ID);
            return View(pRODUCTO);
        }

        // POST: PRODUCTOCliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRO_NOM,PRO_PRECIO,PRO_DESCRIPCION,PRO_STOCK,PRO_FECHA_IN,PRO_ID,CAT_ID,PRV_ID,PRO_IMG")] PRODUCTOS pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CAT_ID = new SelectList(db.CATEGORIA, "CAT_ID", "CAT_NOMBRE", pRODUCTO.CAT_ID);
            ViewBag.PRV_ID = new SelectList(db.PROVEEDOR, "PRV_ID", "PRV_NOMBRE", pRODUCTO.PRV_ID);
            return View(pRODUCTO);
        }

        // GET: PRODUCTOCliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTO = db.PRODUCTOS.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // POST: PRODUCTOCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTOS pRODUCTO = db.PRODUCTOS.Find(id);
            db.PRODUCTOS.Remove(pRODUCTO);
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


        //NUEVO
        [HttpGet]
        public ActionResult Carrito(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }

        //Otro

        [HttpGet]
        public ActionResult Indice(string message = "")
        {
            ViewBag.Message = message;
            var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA).Include(p => p.PROVEEDOR);
            return View(pRODUCTOS.ToList());
        }

        [HttpGet]
        
        public ActionResult CarritoCompra(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }

        //nuevo

        [HttpGet]
        public ActionResult Indice2(string message = "")
        {
            ViewBag.Message = message; 
            var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA).Include(p => p.PROVEEDOR);
            return View(pRODUCTOS.ToList());
        }

        [HttpGet]
        public ActionResult PreFactura(string message = "")
        {
            var id = System.Web.HttpContext.Current.Session["ID"].ToString();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(Convert.ToInt32(id));
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }
    }
}
