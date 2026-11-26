using System.Data.Entity;
using Model;

namespace DataAccess
{
  public class BreakAwayContext : DbContext
  {
    public BreakAwayContext() : base("BreakAway")
    {
        Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BreakAwayContext>());
    }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Lodging> Lodgings { get; set; }
  }
}