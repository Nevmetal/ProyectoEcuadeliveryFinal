using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EcuadeliveryV3._5;

namespace EcuaDeliveryV3._5.Controllers
{
    
    public class ProfileController : Controller
    {
        private BD_EcuaDeliveryEntities db = new BD_EcuaDeliveryEntities();

        // GET: Profile
        [HttpGet]
        public ActionResult Index( string message="")
        {
            ViewBag.Message = message;
            return View();
        }
        [HttpGet]
        public ActionResult Singup(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }
        [HttpGet]
        public ActionResult Singup1(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }
        [HttpGet]
        [Authorize]
        public ActionResult Baja(string message = "")
        {
            ViewBag.Message = message;
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
        [HttpGet]
        [Authorize]
        public ActionResult Detail()
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
        [HttpGet]
        [Authorize]
        public ActionResult Detail1()
        {
            var id = System.Web.HttpContext.Current.Session["ID"].ToString();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROVEEDOR pROVEEDOR = db.PROVEEDOR.Find(Convert.ToInt32(id));
            if (pROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(pROVEEDOR);

        }
        [HttpGet]
        [Authorize]
        public ActionResult Edit(string message = "")
        {
            ViewBag.Message = message;
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
        [HttpGet]
        [Authorize]
        public ActionResult Edit1(string message = "")
        {
            ViewBag.Message = message;
            var id = System.Web.HttpContext.Current.Session["ID"].ToString();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROVEEDOR pROVEEDOR = db.PROVEEDOR.Find(Convert.ToInt32(id));
            if (pROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(pROVEEDOR);
        }
        /*
        public ActionResult Index(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }
        */

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
               // BD_EcuaDeliveryEntities db = new BD_EcuaDeliveryEntities();
                var user = db.USUARIO.FirstOrDefault(e => e.USU_EMAIL == email && e.USU_CONTRASENA == password);
                var userp = db.PROVEEDOR.FirstOrDefault(e => e.PRV_EMAIL == email && e.PRV_CONTRASENA == password);
                //
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(Convert.ToString(user.USU_ID), true);
                    if(user.USU_ESTADO== false)
                    {
                        return RedirectToAction("Logout1");
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Session["ID"] = user.USU_ID;
                        //CID = Convert.ToString(user.USU_ID);
                        return RedirectToAction("Indice", "PRODUCTOCliente");
                    }

                }
                else if(userp != null)
                {
                    FormsAuthentication.SetAuthCookie(Convert.ToString(userp.PRV_ID), true);
                    System.Web.HttpContext.Current.Session["ID"] = userp.PRV_ID;
                    //CID = Convert.ToString(user.USU_ID);
                    
                    return RedirectToAction("Index", "PRODUCTO");
                }
                else
                {
                    return RedirectToAction("Index", new { message = "Email o Contraseña Incorrecta!" });
                }

            }
            else
            {
                /*return RedirectToAction("Index", "Profile");*/
                
                return RedirectToAction("Index", new { message = "Es necesario llenar los campos para realizar el login!" });
            }
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            System.Web.HttpContext.Current.Session["ID"] = null;
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Logout1()
        {
            FormsAuthentication.SignOut();
            System.Web.HttpContext.Current.Session["ID"] = null;
            return RedirectToAction("Index", new { message = "LA CUENTA SE DESACTIVO!" });
        }
        [HttpPost]
        public ActionResult Create(string Nombre, string Apellido, string Email, string Password)
        {
            BD_EcuaDeliveryEntities db = new BD_EcuaDeliveryEntities();
            var usumail = db.USUARIO.Where(a => a.USU_EMAIL.Contains(Email)).ToList();
            if (usumail.Count > 0)
            {
                return RedirectToAction("Singup", new { message = "EL CORREO INGRESADO YA ESTA EN USO!" });

            }
            else if (ModelState.IsValid)
            {
                /*USU_ID,USU_NOMBRE,USU_APELLIDO,USU_CEDULA,USU_TELEFONO,USU_EMAIL,USU_CONTRASENA*/
                USUARIO user = new USUARIO();
                user.USU_NOMBRE = Nombre;
                user.USU_APELLIDO = Apellido;
                user.USU_EMAIL = Email;
                user.USU_CONTRASENA = Password;
                user.USU_ESTADO = true;
                db.USUARIO.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", new { message = "Cuenta Creada" });
            }
            return RedirectToAction("Singup", new { message = "Es necesario llenar los campos para realizar el login!" });
        }
        [HttpPost]
        public ActionResult Create1(string Nombre, string Ruc, string Telefono,string Direccion, string Email, string Password)
        {
            BD_EcuaDeliveryEntities db = new BD_EcuaDeliveryEntities();
            var pROVEEDOR = db.PROVEEDOR.Where(a => a.PRV_EMAIL.Contains(Email)).ToList();
            var prvRuc = db.PROVEEDOR.Where(a => a.PRV_RUC.Contains(Ruc)).ToList();
            if (pROVEEDOR.Count > 0)
            {
                return RedirectToAction("Singup1", new { message = "EL CORREO INGRESADO YA ESTA EN USO!" });
               
            }
            else if(prvRuc.Count > 0)
            {
                return RedirectToAction("Singup1", new { message = "EL RUC INGRESADO YA ESTA EN USO!" });
            }
            else if (ModelState.IsValid)
            {
                /*PRV_ID,PRV_NOMBRE,PRV_RUC,PRV_TELEFONO,PRV_EMAIL,PRV_DESCRIPCION,PRV_DIRECCION,PRV_CONTRASENA*/
                PROVEEDOR user = new PROVEEDOR();
                user.PRV_NOMBRE = Nombre;
                user.PRV_RUC = Ruc;
                user.PRV_EMAIL = Email;
                user.PRV_TELEFONO = Telefono;
                user.PRV_DIRECCION = Direccion;
                user.PRV_CONTRASENA = Password;
                user.PRV_ESTADO = true;
                db.PROVEEDOR.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", new { message = "Cuenta Creada" });
            }
            return RedirectToAction("Singup", new { message = "Es necesario llenar los campos para realizar el login!" });
        }

        [HttpPost]
        //"USU_ID,USU_NOMBRE,USU_APELLIDO,USU_CEDULA,USU_TELEFONO,USU_EMAIL,USU_CONTRASENA"
        public ActionResult Edit(string Nombre, string Apellido, string Cedula, string Telefono,string Email, string Password)
        {
            USUARIO user = new USUARIO();
            user.USU_ID= Convert.ToInt32(System.Web.HttpContext.Current.Session["ID"].ToString());
            user.USU_NOMBRE = Nombre;
            user.USU_APELLIDO = Apellido;
            user.USU_CEDULA = Cedula;
            user.USU_TELEFONO = Telefono;
            user.USU_EMAIL = Email;
            user.USU_CONTRASENA = Password;
            if (ModelState.IsValid)
            {
                
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Detail");
            }
            return RedirectToAction("Edit", new { message = "No se pudo modificar los datos" });
        }
        [HttpPost]
        //"USU_ID,USU_NOMBRE,USU_APELLIDO,USU_CEDULA,USU_TELEFONO,USU_EMAIL,USU_CONTRASENA"
        public ActionResult Baja(string Nombre, string Apellido, string Cedula, string Telefono, string Email, string Password)
        {
            USUARIO user = new USUARIO();
            user.USU_ID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ID"].ToString());
            user.USU_NOMBRE = Nombre;
            user.USU_APELLIDO = Apellido;
            user.USU_CEDULA = Cedula;
            user.USU_TELEFONO = Telefono;
            user.USU_EMAIL = Email;
            user.USU_CONTRASENA = Password;
            user.USU_ESTADO = false;
            if (ModelState.IsValid)
            {

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Logout1");
            }
            return RedirectToAction("Detail", new { message = "No se pudo dar de baja" });
        }
        [HttpPost]
        //"USU_ID,USU_NOMBRE,USU_APELLIDO,USU_CEDULA,USU_TELEFONO,USU_EMAIL,USU_CONTRASENA"
        public ActionResult Edit1(string Nombre, string Ruc, string Telefono, string Direccion, string Descripcion, string Email, string Password)
        {
            PROVEEDOR userp = new PROVEEDOR();
            userp.PRV_ID = Convert.ToInt32(System.Web.HttpContext.Current.Session["ID"].ToString());
            userp.PRV_NOMBRE = Nombre;
            userp.PRV_RUC = Ruc;
            userp.PRV_TELEFONO = Telefono;
            userp.PRV_DIRECCION = Direccion;
            userp.PRV_DESCRIPCION = Descripcion;
            userp.PRV_EMAIL = Email;
            userp.PRV_CONTRASENA = Password;
            
            if (ModelState.IsValid)
            {
                db.Entry(userp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Detail1");
            }
            return RedirectToAction("Edit1", new { message = "No se pudo modificar los datos" });
        }
       
    }
}