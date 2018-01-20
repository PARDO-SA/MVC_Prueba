﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_Prueba.Models.Clases
{
    [Table("SISUsuar")]
    public class Usuario
    {
        private string clave;

        [Key]
        [Display(Name = "Código")]
        public string CodUsr { get; set; }
        [Display(Name = "Nombre")]
        public string NomUsr { get; set; }
        [Display(Name = "Administrador")]
        public string AdmUsr { get; set; }
        [Display(Name = "Password")]
        public string PwdUsr { get; set; }
        [Display(Name = "Vencimiento Pwd")]
        public DateTime VtoPwdUsr { get; set; }
        [Display(Name = "Inactivo")]
        public Boolean Inactivo { get; set; }
        [Column("codgrp")]
        [Display(Name = "Grupo")]
        public string Grupo { get; set; }


        
    }
}