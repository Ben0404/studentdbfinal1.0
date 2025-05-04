using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace studentdbfinal1._0
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=studentdbcontextfinal")
        {
        }

        public virtual DbSet<Studentquery1> Studentquery1 { get; set; }
        // public virtual DbSet<Studentquery1> Studentquery1final { get; set; } // removed to avoid EF conflict

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Studentquery1>()
                .Property(e => e.Assessment1Mark)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Studentquery1>()
                .Property(e => e.Assessment2Mark)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Studentquery1>()
                .Property(e => e.OverallModuleMark)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Studentquery1>()
                .Property(e => e.Assessment1Mark)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Studentquery1>()
                .Property(e => e.Assessment2Mark)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Studentquery1>()
                .Property(e => e.OverallModuleMark)
                .HasPrecision(5, 2);
        }
    }
}
