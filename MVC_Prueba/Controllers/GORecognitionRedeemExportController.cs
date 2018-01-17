using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MVC_Prueba.Models;

namespace MVC_Prueba.Controllers
{
    public class GORecognitionRedeemExportController : Controller
    {
        // GET: GORecognitionRedeemExport
        public ActionResult Index()
        {
            return View(new List<GORecognitionRedeemExport>());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            List<GORecognitionRedeemExport> Redeems = new List<GORecognitionRedeemExport>();
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                //Read the contents of CSV file.
                string csvData = System.IO.File.ReadAllText(filePath);

                int linea = 0;
                //Execute a loop over the rows.
                foreach (string row in csvData.Split('\n'))
                {                    
                    if (!string.IsNullOrEmpty(row))
                    {
                        Redeems.Add(new GORecognitionRedeemExport
                        {
                            Fecha = row.Split(',')[0].ToString().Replace('\"', ' ').Trim(),
                            Numero = row.Split(',')[1],
                            Detalle = row.Split(',')[2],
                            FechaUso = row.Split(',')[3],
                            Tipo = row.Split(',')[4],
                            Cantidad = row.Split(',')[5],
                            DireccionEnvio = row.Split(',')[6],
                            Duracion = row.Split(',')[7],
                            Opcion = row.Split(',')[8],
                            Puntos = row.Split(',')[9],
                            Estado = row.Split(',')[10],
                            Documento = row.Split(',')[11],
                            ApellidoNombre = row.Split(',')[12],
                            Contacto = row.Split(',')[13],
                            Genero = row.Split(',')[14],
                            FechaNacimiento = row.Split(',')[15]//,
                            //ReportaA = row.Split(',')[16]
                        });
                }
                }
            }

            return View(Redeems);
        }
    }
}