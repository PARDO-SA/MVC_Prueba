using System;
using System.Data.Entity;

namespace MVC_Prueba.Models.Clases
{
    public class CentralDBContext : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<ComisionesBP> ComisionesBPs { get; set; }

        object placeHolderVariable;
        public System.Data.Entity.DbSet<MVC_Prueba.Models.Clases.Comision> Comisions { get; set; }
    } 
}