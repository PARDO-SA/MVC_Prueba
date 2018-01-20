using System;
using System.Data.Entity;

namespace MVC_Prueba.Models.Clases
{
    public class SistemaDBContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

    }
}