using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_Prueba.Models
{
    public class GORecognitionRedeemExport
    {
        [Display(Name = "Fecha de transacción")]
        public string Fecha { get; set; }
        [Display(Name = "Número de transacción")]
        public string Numero { get; set; }
        [Display(Name = "Detalle")]
        public string Detalle { get; set; }
        [Display(Name = "Fecha de Uso")]
        public string FechaUso { get; set; }
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }
        [Display(Name = "Cantidad")]
        public string Cantidad { get; set; }
        [Display(Name = "Dirección de envío")]
        public string DireccionEnvio { get; set; }
        [Display(Name = "Duración")]
        public string Duracion { get; set; }
        [Display(Name = "Opción")]
        public string Opcion { get; set; }
        [Display(Name = "Puntos")]
        public string Puntos { get; set; }
        [Display(Name = "Estado")]
        public string Estado { get; set; }
        [Display(Name = "Documento")]
        public string Documento { get; set; }
        [Display(Name = "Nombre y Apellido")]
        public string ApellidoNombre { get; set; }
        [Display(Name = "Contacto")]
        public string Contacto { get; set; }
        [Display(Name = "Género")]
        public string Genero { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        public string FechaNacimiento { get; set; }
        [Display(Name = "Reporta a")]
        public string ReportaA { get; set; }
    }

}