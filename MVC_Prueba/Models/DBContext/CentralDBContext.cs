using System;
using System.Data.Entity;

namespace MVC_Prueba.Models
{
    public class CentralDBContext : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }
    } 
}