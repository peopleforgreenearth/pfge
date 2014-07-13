using System.Data.Entity;

namespace PFGE.Models
{
    public class PFGEEntities : DbContext
    {
        public DbSet<Place> Places { get; set; }
    }
}