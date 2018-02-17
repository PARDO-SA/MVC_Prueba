using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Prueba.Models.Clases;
using MVC_Prueba.Controllers;


namespace MVC_Prueba.Controllers
{
    public class LoginController : Controller
    {

        //Login
        public ActionResult Logueo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logueo(Usuario user)
        {
            using (SistemaDBContext db = new SistemaDBContext())
            {
                //Filtro solamente por la clave primaria (Username)
                //var usr = db.SISUsuarios.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                var usr = db.Usuarios.Where(u => u.CodUsr == user.CodUsr.ToUpper()).FirstOrDefault();
                if (usr != null)
                {
                    string pwddecript = "";
                    if (usr.PwdUsr.Trim() != null)
                    {
                        //llamo a función para desencriptar password
                        pwddecript = DecryptPwd(usr.PwdUsr);
                    }

                    if ((string.IsNullOrEmpty(user.PwdUsr)) || (user.PwdUsr.Trim() == pwddecript) )
                    {
                        //CREO VARIABLES DE SESIÓN
                        Session["Codusr"] = usr.CodUsr.ToString();
                        Session["Nomusr"] = usr.NomUsr.ToString();
                        return RedirectToAction("Resumen","ComisionesBP",null);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuario o Contraseña Incorrecta");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Usuario o Contraseña Incorrecta");
                }

            }
            return View();
        }

        public ActionResult Loggedin()
        {
            if (Session["Codusr"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        
        public ActionResult Salir()
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            return RedirectToAction("Logueo");
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
