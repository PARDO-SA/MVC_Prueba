using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_Prueba.Models.Clases
{
    [Table("PAR_Comisiones_Articulos")]
    public class ComisionArticulo
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        public int IdComi { get; set; }

        [Column(Order = 1)]
        [Display(Name = "Artículo")]
        [Required, StringLength(20)]
        public string CodArtComi { get; set; }

        [Column(Order = 2)]
        [Display(Name = "Incluido/Excluido")]
        [Required, StringLength(1)]
        public string Tipo { get; set; }
    }
}