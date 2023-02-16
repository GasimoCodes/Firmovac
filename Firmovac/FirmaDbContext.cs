using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Firmovac.DataDefinitions;

namespace Firmovac
{
    /// <summary>
    /// Entity Framework Database Context for the Firmovac db
    /// </summary>
    public class FirmaDbContext : DbContext
    {

        public DbSet<ColumnDefinition> ColumnDefinitions { get; set; }
        public DbSet<Firma> Firms { get; set; }
        public DbSet<FirmaEvent> FirmaEvents { get; set; }
        public DbSet<FirmaContact> FirmaContacts { get; set; }
        public DbSet<FirmaSource> FirmaSources { get; set; }
        public DbSet<OborDefinition> Obors { get; set; }

        public FirmaDbContext()
        {
        }


        public FirmaDbContext(DbContextOptions<FirmaDbContext> options)
        : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql("server=localhost;user=root;password=;database=crmskchccz", new MySqlServerVersion(new Version(8, 0, 29))).LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OborDefinition>().HasData(new OborDefinition[] {
                new OborDefinition{Id = 1, Name="IT"},
                new OborDefinition{Id = 2, Name="ELE"},
                new OborDefinition{Id = 3, Name="AM"},
                new OborDefinition{Id = 4, Name="N/A"}
            });

            modelBuilder.Entity<FirmaSource>().HasData(new FirmaSource[] {
                new FirmaSource{Id = 1, Name="IT"},
                new FirmaSource{Id = 2, Name="Praxe žáků"},
                new FirmaSource{Id = 3, Name="Prac. Nab. z portálu"},
            });


        }


    }
}