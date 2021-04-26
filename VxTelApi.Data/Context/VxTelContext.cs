using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using VxTel.Domain.Entities;

namespace VxTelApi.Data.Context
{
    public class VxTelContext : DbContext
    {
        public VxTelContext()
        {
            
        }
        public VxTelContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<CodigoAreaTarifa> Tarifa { get; set; }
        public DbSet<Plano> Plano { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("VxTelDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CodigoAreaTarifa>(
                p =>
                {
                    p.HasKey("Id");
                    p.Property(e => e.CodigoOrigem);
                    p.Property(e => e.CodigoDestino);
                    p.Property(e => e.ValorPorMinuto);
                }
            );

            modelBuilder.Entity<CodigoAreaTarifa>()
                .HasData(

                new CodigoAreaTarifa("011", "016", 1.9M),
                new CodigoAreaTarifa("016", "011", 2.9M),
                new CodigoAreaTarifa("011", "017", 1.7M),
                new CodigoAreaTarifa("017", "011", 2.7M),
                new CodigoAreaTarifa("011", "018", 0.9M),
                new CodigoAreaTarifa("018", "011", 1.9M)
                );

            modelBuilder.Entity<Plano>(
                p =>
                {
                    p.HasKey("Id");
                    p.Property(e => e.NomePlano);
                    p.Property(e => e.MinutosFranquia);
                    p.Property(e => e.AcrescimoAlemFranquia);
                }
            );

            modelBuilder.Entity<Plano>()
                .HasData(

                    new Plano("FaleMais 30", 30, 0.1M),
                    new Plano("FaleMais 60", 60, 0.1M),
                    new Plano("FaleMais 120", 120, 0.1M)
                );
        }
    }
}
