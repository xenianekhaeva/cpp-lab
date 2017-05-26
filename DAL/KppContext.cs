using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class KppContext : DbContext
    {
        public KppContext() : base("KppContext")
        {
        }

        public DbSet<Visitor> Visitors { get; set; }

    }
}
