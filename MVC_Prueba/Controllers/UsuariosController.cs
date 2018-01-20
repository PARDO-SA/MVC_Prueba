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
    public class UsuariosController : Controller
    {
        private SistemaDBContext db = new SistemaDBContext();

        public ActionResult Index(string searchString)
        {
            //var SucursalLst = new List<string>();
            //var SucursalQry = from d in db.Empleados orderby d.CodSuc select d.CodSuc;

            //SucursalLst.AddRange(SucursalQry.Distinct());
            //ViewBag.sucursal = new SelectList(SucursalLst);

            var usuarios = from m in db.Usuarios select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                usuarios = usuarios.Where(s => s.NomUsr.Contains(searchString));
            }

            //if (!string.IsNullOrEmpty(sucursal))
            //{
            //    usuarios = usuarios.Where(x => x.CodSuc == sucursal);
            //}

            //return View(db.Empleados.ToList());
            return View(usuarios);
            //return View(db.Usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            } else {
                usuario.PwdUsr = DecryptPwd(usuario.PwdUsr);
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodUsr,NomUsr,AdmUsr,PwdUsr,VtoPwdUsr,Inactivo,CodGrp")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodUsr,NomUsr,AdmUsr,PwdUsr,VtoPwdUsr,Inactivo,CodGrp")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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

        [NonAction]
        public string DecryptPwd(string clave)
        {
            string CRYPTCHARS = "?qwertyuiopasdfghjklñzxcvbnm 1234567890ºª\\!|@·#$%&/()='¿¡*+]`^[´¨{çÇ},;.:-_QWERTYUIOPASDFGHJKLÑZXCVBNM~";
            string decrypt = "";
            int caracter;
            int counter = 0;
            for (int n = 0; n < clave.TrimEnd().Length; n++)
            {
                counter++;
                caracter = System.Text.Encoding.ASCII.GetBytes(clave.TrimEnd().Substring(n, 1))[0];
                caracter = caracter - counter;
                decrypt += CRYPTCHARS.Substring(caracter - 1, 1);
            }
            return decrypt;
        }

    }
}
