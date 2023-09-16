using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Bdata.Data.Entity;

namespace Negocio.Bdata.Data
{
    public class Context:DbContext
    {
        public DbSet<Personas> personas => Set<Personas>();

        public DbSet<Venta> ventas => Set<Venta>();

        public DbSet<Cuota> cuotas => Set<Cuota>();

        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}
