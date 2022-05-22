using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcuadeliveryV3._5;

namespace EcuadeliveryV3._5.Controllers
{
    public class HomeController : Controller
    {
        private BD_EcuaDeliveryEntities db = new BD_EcuaDeliveryEntities();
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
        public ActionResult Indexall()
        {
            var pRODUCTOS = db.PRODUCTOS;
            return View(pRODUCTOS.ToList());
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


        [HttpGet]
        public ActionResult CarritoCompra(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
      
    }
}