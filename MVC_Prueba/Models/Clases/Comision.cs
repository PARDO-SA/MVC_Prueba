using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_Prueba.Models.Clases
{
    [Table("PAR_Comisiones")]
    public class Comision
    {
        [Key, Column(Order = 0)]
        [Display(Name = "ID")]
        public int IdComi { get; set; }

        [Column(Order = 1)]
        [Display(Name = "Descripción")]
        [Required, StringLength(30)]
        public string DesComi { get; set; }

        [Column(Order = 2)]
        [Display(Name = "Fecha Vigencia Desde")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime FecVigDesComi { get; set; }

        [Column(Order = 3)]
        [Display(Name = "Fecha Vigencia Hasta")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? FecVigHasComi { get; set; }

        [Column(Order = 4)]
        [Display(Name = "Rubro"), StringLength(3)]
        public string CodNivArt1Comi { get; set; }

        [Column(Order = 5)]
        [Display(Name = "SubRubro"), StringLength(3)]
        public string CodNivArt2Comi { get; set; }

        [Column(Order = 6)]
        [Display(Name = ""), StringLength(3)]
        public string CodNivArt3Comi { get; set; }

        [Column(Order = 7)]
        [Display(Name = "Marca"), StringLength(10)]
        public string MarcaComi { get; set; }

        [Column(Order = 8)]
        [Display(Name = "Articulos Incluye")]
        public Boolean ArtIncComi { get; set; }

        [Column(Order = 9)]
        [Display(Name = "Articulos Excluye")]
        public Boolean ArtExcComi { get; set; }

        [Column(Order = 10)]
        [Required]
        [Display(Name = "Para Vendedores")]
        public Boolean VendeComi { get; set; }

        [Column(Order = 11)]
        [Display(Name = "Importe x Unidad")]
        public decimal? ImpComi { get; set; }

        [Column(Order = 12)]
        [Display(Name = "Porcentaje"), Range(0, 100)]
        public decimal? PorComi { get; set; }

        [Column(Order = 13)]
        [Required]
        [Display(Name = "Para Resto Sucursal")]
        public Boolean RestoComi { get; set; }

        [Column(Order = 14)]
        [Display(Name = "Importe x Unidad")]
        public decimal? ImpRestoComi { get; set; }

        [Column(Order = 15)]
        [Display(Name = "Porcentaje"), Range(0, 100)]
        public decimal? PorRestoComi { get; set; }

        [Column(Order = 16)]
        [Required]
        [Display(Name = "Inactivo")]
        public Boolean Inactivo { get; set; }

        [Column(Order = 17)]
        [Required]
        [Display(Name = "Función")]
        public int IdFuncion { get; set; }

        public virtual ICollection<ComisionArticulo> IncluidosExcluidos { get; set; }
    }
}