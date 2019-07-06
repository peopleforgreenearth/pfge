using Microsoft.EntityFrameworkCore;
using PFGE.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
namespace PFGE.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        //public DbSet<Place> Places { get; set; }
        //public DbSet<PlacePhoto> PlacePhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Configurations.

            modelBuilder.Entity<Core.Domain.Place>().HasKey("PlaceId");

        }
    }
}
