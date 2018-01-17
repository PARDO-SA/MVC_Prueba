using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_Prueba.Models
{
    [Table("PAR_EMPLE")]
    public class Empleado
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Apellido y Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Cod. Vendedor")]
        public string CodVen { get; set; }
        [Display(Name = "Sucursal")]
        public string CodSuc { get; set; }
        [Display(Name = "Función Primaria")]
        public string FuncionP { get; set; }
        [Display(Name = "Función Sec.")]
        public string FuncionS { get; set; }
        [Display(Name = "Inactivo")]
        public Boolean Inactivo { get; set; }
        [Display(Name = "Legajo")]
        public int Legajo { get; set; }
    }

}