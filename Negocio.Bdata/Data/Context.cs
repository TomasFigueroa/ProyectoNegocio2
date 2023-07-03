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
        public DbSet<Cuenta> cuentas => Set<Cuenta>();

        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}
