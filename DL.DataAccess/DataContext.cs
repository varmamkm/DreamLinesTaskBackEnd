using DL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DL.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<CabinType> CabinTypes { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Route> Routes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options){  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Trip>(entity =>
            //{
            //    entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            //});

            modelBuilder.Entity<CabinType>(entity =>
            {        
                entity.HasOne(d => d.Ship)
                    .WithMany(p => p.CabinTypes)
                    .HasForeignKey(d => d.ShipId)  ;
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey("Day", "TripId", "PortId");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.TripId);

                entity.HasOne(d => d.Port)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.PortId);
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasOne(d => d.Ship)
                    .WithMany(p => p.trips)
                    .HasForeignKey(d => d.ShipId);

                entity.HasOne(d => d.Company)
                   .WithMany(p => p.trips)
                   .HasForeignKey(d => d.CompanyId);

                entity.HasOne(d => d.CabinType)
                  .WithMany(p => p.trips)
                  .HasForeignKey(d => d.CabinTypeId);
            });

            modelBuilder.Entity<Company>().HasData(new Company { Id = 119055, Title = "MSC Cruises" },
                                                   new Company { Id = 131168, Title = "Celebrity Cruises" },
                                                    new Company { Id = 93195, Title = "Royal Caribbean" });

            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 119075, CompanyId = 119055, Title = "MSC Fantasia" },
                                                new Ship { Id = 119463, CompanyId = 119055, Title = "MSC Splendida" });

            modelBuilder.Entity<CabinType>().HasData(new CabinType { Id = 119375, ShipId = 119075, Title = "Balcony Cabin: Fantastica B2" });
            modelBuilder.Entity<CabinType>().HasData(new CabinType { Id = 119395, ShipId = 119075, Title = "Suite: Aurea S3" });
            modelBuilder.Entity<CabinType>().HasData(new CabinType { Id = 843466, ShipId = 119075, Title = "Suite: Aurea SP3" });
            modelBuilder.Entity<CabinType>().HasData(new CabinType { Id = 119538, ShipId = 119463, Title = "Suite: Executive and Family YC2" });
            modelBuilder.Entity<CabinType>().HasData(new CabinType { Id = 119542, ShipId = 119463, Title = "Balcony Cabin: Aurea B3" });

            modelBuilder.Entity<Port>().HasData(new Port { Id = 868857, Title = "Sandefjord, Norway", Country = "Norway", CountryCode = "NO" },
                                    new Port { Id = 332439, Title = "St. Florent, Corsica, France", Country = "France", CountryCode = "FR" },
                                     new Port { Id = 15118272, Title = "Ari Atoll, Maldives", Country = "Maldives", CountryCode = "MV" });

        }

    }
}
