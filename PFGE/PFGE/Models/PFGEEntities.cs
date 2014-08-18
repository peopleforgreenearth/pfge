using System.Data.Entity;

namespace PFGE.Models
{
    public class PFGEEntities : DbContext
    {
        public DbSet<Place> Places { get; set; }
        public DbSet<PlacePhoto> PlacePhotos { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventPhoto> EventPhotos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Configurations.
        }

    }
}