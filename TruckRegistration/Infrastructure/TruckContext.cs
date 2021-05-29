using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using TruckRegistration.Domain.Model;

namespace TruckRegistration.Infrastructure
{
    public sealed class TruckContext : DbContext
    {
        public TruckContext(DbContextOptions<TruckContext> options) : base(options)
        {
            Database.SetCommandTimeout(TimeSpan.FromSeconds(60));
        }


        #region DbSets

        public DbSet<Truck> Trucks { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Truck>()
                .ToTable("Trucks")
                .HasKey(k=> k.Id);

            //the system will generate the key value
            modelBuilder.Entity<Truck>().Property(p => p.Id)
                .ValueGeneratedNever();
        }
    }
}
