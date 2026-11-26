using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using DataAccess;
using Model;
using System.Data.Objects.DataClasses;

/*
 As you perform operations on your object instances, Entity Framework uses its change
tracker to keep track of what you have done.
 */
namespace BreakAwayConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      Database.SetInitializer(new InitializeBagaDatabaseWithSeedData());

        DeleteTrip();
    }

    private static void AddMachuPicchu()
    {
      using (var context = new BreakAwayContext())
      {
        var machuPicchu = new Destination
        {
          Name = "Machu Picchu",
          Country = "Peru"
        };

        context.Destinations.Add(machuPicchu);
        context.SaveChanges();
      }
    }

    private static void ChangeGrandCanyon()
    {
      using (var context = new BreakAwayContext())
      {
        var canyon = (from d in context.Destinations
                      where d.Name == "Grand Canyon"
                      select d).Single();

        canyon.Description = "227 mile long canyon.";
        context.SaveChanges();
      }
    }

    private static void DeleteWineGlassBay()
    {
      using (var context = new BreakAwayContext())
      {
        var bay = (from d in context.Destinations
                   where d.Name == "Wine Glass Bay"
                   select d).Single();

        context.Destinations.Remove(bay);
        context.SaveChanges();
      }
    }

    /*
     Deleting without loading from the database (P47)
     * If you know you need to delete an entity, but it’s not already in memory, it’s a little
inefficient to retrieve that entity from the database just to delete it. If you know the key
of the entity you want to delete, you can attach a stub that represents the entity to be
deleted, and then delete this stub. A stub is an instance of an entity that just has the
key value assigned. The key value is all that’s required for deleting entities.
     * 
     * When attaching a stub you use the DbSet.Attach method to let Entity Framework know
that it’s an existing entity. Once an entity is attached, it behaves just like an entity that
was retrieved from the database.
     * 
     * var toDelete = new Destination { DestinationId = 2 };
        context.Destinations.Attach(toDelete);
        context.Destinations.Remove(toDelete);
        context.SaveChanges();
     * 
     * 
     * 
     * context.Database.ExecuteSqlCommand(
"DELETE FROM baga.Locations WHERE LocationName = 'Hawaii'");
     */

    /*It is about deleting related data. In this case, the relationship is optional. 
     * However the child entity must show up in memory.*/
    private static void DeleteTrip()
    {
      using (var context = new BreakAwayContext())
      {
        var trip = (from t in context.Trips
                    where t.Description == "Trip from the database"
                    select t).Single();

        /*However the child entity must show up in memory.
        var res = (from r in context.Reservations
                   where r.Trip.Description == "Trip from the database"
                   select r).Single();*/

        context.Trips.Remove(trip);
        context.SaveChanges();
      }
    }

    /*In this case, the relationship is mandatory. Need to use cascade delete.*/
    private static void DeleteGrandCanyon()
    {
        /*EF takes care of the cascade deletion in this case. Have to bring all of the related objects in the memory.*/
        using (var context = new BreakAwayContext())
        {
            var canyon = (from d in context.Destinations
                          where d.Name == "Grand Canyon"
                          select d).Single();
            context.Entry(canyon)
            .Collection(d => d.Lodgings)
            .Load();
            context.Destinations.Remove(canyon);
            context.SaveChanges();
        }

      /*Database takes care of the cascade deletion in this case.*/ 
      using (var context = new BreakAwayContext())
      {
        var canyon = (from d in context.Destinations
                      where d.Name == "Grand Canyon"
                      select d).Single();

        context.Destinations.Remove(canyon);
        context.SaveChanges();
      }
    }

    /*SaveChanges is transactional, meaning that it either pushes all of the
    changes to the database or none of them.*/
    private static void MakeMultipleChanges()
    {
      using (var context = new BreakAwayContext())
      {
        var niagaraFalls = new Destination
        {
          Name = "Niagara Falls",
          Country = "USA"
        };
        context.Destinations.Add(niagaraFalls);
        var wineGlassBay = (from d in context.Destinations
                            where d.Name == "Wine Glass Bay"
                            select d).Single();
        wineGlassBay.Description = "Picturesque bay with beaches.";
        context.SaveChanges();
      }
    }

    /*You may have noticed that DbSet.Add returns an object. It returns the same object that
    you pass into the method. This may seem a little strange at first,*/
    private static void FindOrAddPerson()
    {
      using (var context = new BreakAwayContext())
      {
        var ssn = 123456789;

        var person = context.People.Find(ssn)
          ?? context.People.Add(new Person
          {
            SocialSecurityNumber = ssn,
            FirstName = "<enter first name>",
            LastName = "<enter last name>"
          });

        Console.WriteLine(person.FirstName);
      }
    }

    /*Working with relationships*/
    /*Given that a relationship can be represented by up to three properties (two navigation
properties and a foreign key property),
     
     Rather than waiting for
SaveChanges to fix up the properties, you can trigger this fix-up on demand by calling
DetectChanges or have it happen in real-time by using change tracking proxies.
     */
    private static void NewGrandCanyonResort()
    {
      using (var context = new BreakAwayContext())
      {
        var resort = new Resort//The first call ensures that the context knows that resort is new and needs to be inserted into the database.
        {
          Name = "Pete's Luxury Resort"
        };

        context.Lodgings.Add(resort);

        var canyon = (from d in context.Destinations
                      where d.Name == "Grand Canyon"
                      select d).Single();
        //or use resort.Destination = canyon; resort.DestinationId = canyon.DestinationId;
        canyon.Lodgings.Add(resort);
        context.SaveChanges();
      }
    }

    /*There is no need to remove the existing
relationship between the Grand Hotel and the Grand Canyon. Entity Framework
knows that we want the relationship to be updated, which implies it will no longer
point to the old value.*/
    private static void ChangeLodgingDestination()
    {
      using (var context = new BreakAwayContext())
      {
        var hotel = (from l in context.Lodgings
                     where l.Name == "Grand Hotel"
                     select l).Single();

        /*var a = from l in context.Lodgings
                where l.Name == "Grand Hotel"
                select l;
        String str = ((System.Data.Objects.ObjectQuery)a).ToTraceString();*/
          
        var reef = (from d in context.Destinations
                    where d.Name == "Great Barrier Reef"
                    select d).Single();

        hotel.Destination = reef;//hotel.DestinationId = reef.DestinationId;
        context.SaveChanges();
      }
    }

    /*Removing relationships by changing the foreign key is only possible with
nullable properties*/
    private static void RemovePrimaryContact()
    {
        /*
         using (var context = new BreakAwayContext())
          {
          var davesDump = (from l in context.Lodgings
          where l.Name == "Dave's Dump"
          select l).Single();
          context.Entry(davesDump)
          .Reference(l => l.PrimaryContact)
          .Load();
          davesDump.PrimaryContact = null;
          context.SaveChanges();
         }
         */

        using (var context = new BreakAwayContext())
      {
        var davesDump = (from l in context.Lodgings
                         where l.Name == "Dave's Dump"
                         select l).Single();

        davesDump.PrimaryContactId = null;
        context.SaveChanges();
      }
    }


    /*Working with change tracking (It is all about performance)*/
    /*Throughout this chapter you have seen that Entity Framework keeps track of the
changes you make to your objects. Entity Framework uses its change tracker to do this.*/

    /*
     Snapshot change tracking:
     * When Entity Framework needs to know what changes have been made,
it will scan each object and compare its current values to the snapshot. This process
of scanning each object is triggered through a method of ChangeTracker called
DetectChanges.
     * 
     Change tracking proxies
     * 
     * The other mechanism for tracking changes is through change tracking proxies,
which allow Entity Framework to be notified of changes as they are made.
     */

    /*In most cases DetectChanges is fast enough that it doesn’t cause performance issues.
However, if you have a very large number of objects in memory or you are performing
a lot of operations on DbContext in quick succession, the automatic DetectChanges behavior
may be a performance concern. Fortunately you have the option to switch off
the automatic DetectChanges behavior and call it manually when you know that it needs
to be called.*/
    private static void ManualDetectChanges()
    {
      using (var context = new BreakAwayContext())
      {
        context.Configuration.AutoDetectChangesEnabled = false;

        var reef = (from d in context.Destinations
                    where d.Name == "Great Barrier Reef"
                    select d).Single();

        reef.Description = "The world's largest reef!";

        Console.WriteLine("Before DetectChanges: {0}", context.Entry(reef).State);
        context.ChangeTracker.DetectChanges();
        Console.WriteLine("After DetectChanges: {0}", context.Entry(reef).State);
      }
    }

    /*However if we were performing a series of API calls on DbContext without changing any
objects in between, we could avoid some unnecessary execution of the DetectChanges
process. The AddMultipleDestinations method shown in Example 3-15 demonstrates
this. (P62)*/
    private static void AddMultipleDestinations()
    {
      using (var context = new BreakAwayContext())
      {
        context.Configuration.AutoDetectChangesEnabled = false;

        context.Destinations.Add(new Destination
        {
          Name = "Paris",
          Country = "France"
        });

        context.Destinations.Add(new Destination
        {
          Name = "Grindelwald",
          Country = "Switzerland"
        });

        context.Destinations.Add(new Destination
        {
          Name = "Crete",
          Country = "Greece"
        });

        context.SaveChanges();
      }
    }

    /*Using DetectChanges to Trigger Relationship Fix-up*/
    private static void DetectRelationshipChanges()
    {
      using (var context = new BreakAwayContext())
      {
        var hawaii = (from d in context.Destinations
                      where d.Name == "Hawaii"
                      select d).Single();

        var davesDump = (from l in context.Lodgings
                         where l.Name == "Dave's Dump"
                         select l).Single();

        context.Entry(davesDump)
          .Reference(l => l.Destination)
          .Load();

        hawaii.Lodgings.Add(davesDump);//We could wait until we call SaveChanges, or any other method, which triggers DetectChanges,
        Console.WriteLine("Before DetectChanges: {0}", davesDump.Destination.Name);
        context.ChangeTracker.DetectChanges();
        Console.WriteLine("After DetectChanges: {0}", davesDump.Destination.Name);
      }
    }


    /*Enabling and working with change tracking proxies (P64)*/
    /*If your performance profiler has pinpointed excessive calls to DetectChanges as a problem
or you prefer relationship fix-up to occur in real time, there is another option—the
change tracking proxies mentioned earlier.*/

    /*The change tracking proxy will override any collection navigation
properties and use its own collection type (EntityCollection<TEntity>). This collection
type will track any changes to the collection and report them to the change tracker.*/
    private static void TestForChangeTrackingProxy()
    {
      using (var context = new BreakAwayContext())
      {
        var destination = context.Destinations.First();
        var isProxy = destination is IEntityWithChangeTracker;
        Console.WriteLine("Destination is a proxy: {0}", isProxy);
      }
    }


    /*Ensuring the New Instances Get Proxies*/
    /*Entity Framework will automatically create proxies for the results of any queries you
run. However, if you just use the constructor of your POCO class to create new objects,
these will not be proxies. In order to get proxies you need to use the DbSet.Create
method to get new instances of an entity. This rule is the same as when working with
POCOs with ObjectContext and ObjectSet.*/
    /*so it’s generally recommended
that you use DbSet.Create to create new instances so that
all entities in the set are change tracking proxies.*/
    private static void CreatingNewProxies()
    {
      using (var context = new BreakAwayContext())
      {
        var nonProxy = new Destination();
        nonProxy.Name = "Non-proxy Destination";
        nonProxy.Lodgings = new List<Lodging>();

        var proxy = context.Destinations.Create();
        proxy.Name = "Proxy Destination";

        context.Destinations.Add(proxy);
        context.Destinations.Add(nonProxy);

        var davesDump = (from l in context.Lodgings
                         where l.Name == "Dave's Dump"
                         select l).Single();

        context.Entry(davesDump)
          .Reference(l => l.Destination)
          .Load();

        Console.WriteLine("Before changes: {0}", davesDump.Destination.Name);

        nonProxy.Lodgings.Add(davesDump);
        Console.WriteLine("Added to non-proxy destination: {0}", davesDump.Destination.Name);

        proxy.Lodgings.Add(davesDump);
        Console.WriteLine("Added to proxy destination: {0}", davesDump.Destination.Name);
      }
    }

    /*Fetching Entities Without Change Tracking*/
    /*Fortunately Entity Framework includes an AsNoTracking method that can be used to
execute a no-tracking query.*/
    /*Because this is a no-tracking query, the context is not keeping track of any changes
made to the Destinations. If you were to modify a property of one of the Destina
tions and call SaveChanges, the changes would not be sent to the database.*/
    /*Fetching data without change tracking will usually only provide a noticeable
performance gain when you are fetching larger amounts of data
for read-only display.*/
    private static void PrintDestinationsWithoutChangeTracking()
    {
      using (var context = new BreakAwayContext())
      {
        foreach (var destination in context.Destinations.AsNoTracking())
        {
          Console.WriteLine(destination.Name);
        }
      }
    }
  }
}
