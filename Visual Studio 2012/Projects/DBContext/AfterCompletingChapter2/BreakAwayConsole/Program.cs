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
 LINQ to Objects
 LINQ to Entities
 *       Entities to SQL        ObjectContext API using the IObjectContextAdapter
 LINQ to SQL?
 *       
 */


namespace BreakAwayConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      //Database.SetInitializer(new InitializeBagaDatabaseWithSeedData());

        ListenToLocalChanges();
    }

    private static void PrintAllDestinations()
    {
      using (var context = new BreakAwayContext())
      {
        foreach (var destination in context.Destinations)//will not be loaded into memory.
        {
          Console.WriteLine(destination.Name);
        }
      }
    }

    private static void PrintAllDestinationsTwice()
    {
      using (var context = new BreakAwayContext())
      {
        var allDestinations = context.Destinations;

        foreach (var destination in allDestinations)//Iterate over the contents of a DbSet
        {//It is the first trip to database.
          Console.WriteLine(destination.Name);
        }
        foreach (var destination in allDestinations)
        {//It is the second trip to database.
          Console.WriteLine(destination.Name);
        }

        foreach (var destination in allDestinations.ToList())
        {//ToList() will load the result set into memory and stop visiting database more than once.
            Console.WriteLine(destination.Name);
        }


      }
    }

    private static void PrintAllDestinationsSorted()
    {
      using (var context = new BreakAwayContext())
      {
        var query = from d in context.Destinations
                    orderby d.Name
                    select d;

        foreach (var destination in query)
        {
          Console.WriteLine(destination.Name);
        }
      }
    }

    private static void PrintAustralianDestinations()
    {
      using (var context = new BreakAwayContext())
      {
        var query = from d in context.Destinations
                    where d.Country == "Australia"
                    select d;

        foreach (var destination in query)
        {
          Console.WriteLine(destination.Name);
        }
      }
    }

    private static void PrintDestinationNameOnly()
    {
      using (var context = new BreakAwayContext())
      {
        var query = from d in context.Destinations
                    where d.Country == "Australia"
                    orderby d.Name
                    select d.Name;

        foreach (var name in query)
        {
          Console.WriteLine(name);
        }
      }
    }

    private static void FindDestination()
    {
      Console.Write("Enter id of Destination to find: ");
      var id = int.Parse(Console.ReadLine());

      using (var context = new BreakAwayContext())
      {
        var destination = context.Destinations.Find(id);
        //'Find' look in both database and memory. Linq to Entity and Entity to Object. (P21)
          /*
           1. Look in memory for an existing entity that has been loaded from the database or attached to the context.
           2. Look at added objects that have not yet been saved to the database.
           3. Look in the database for entities that have not yet been loaded into memory.
           */
        if (destination == null)
        {
          Console.WriteLine("Destination not found!");
        }
        else
        {
          Console.WriteLine(destination.Name);
        }
      }
    }

    private static void FindGreatBarrierReef()
    {//.Single()
     //.SingleOrDefault()
     //.First()
     //.FirstOrDefault()
      using (var context = new BreakAwayContext())
      {
        var query = from d in context.Destinations
                    where d.Name == "Great Barrier Reef"
                    select d;

        var reef = query.SingleOrDefault();

        if (reef == null)
        {
          Console.WriteLine("Can't find the reef!");
        }
        else
        {
          Console.WriteLine(reef.Description);
        }
      }
    }

    private static void GetLocalDestinationCount()
    {
      using (var context = new BreakAwayContext())
      {
        /*foreach (var destination in context.Destinations)
        {
          Console.WriteLine(destination.Name);
        }*/

        var count = context.Destinations.Local.Count;//The in-memory data for a DbSet is available via the Local property. (P25)
                                                    //Local will return all the data that has been loaded from the database plus any newly added data.
        Console.WriteLine("Destinations in memory: {0}", count);
      }
    }

    private static void GetLocalDestinationCountWithLoad()
    {
      using (var context = new BreakAwayContext())
      {
        context.Destinations.Load();//Using the Load method to bring data into memory.  (P26)
                                    //Load is actually an extension method on IQueryable<T> and is defined in the System.Data.Entity namespace.
        var count = context.Destinations.Local.Count;
        Console.WriteLine("Destinations in memory: {0}", count);
      }
    }

    private static void LoadAustralianDestinations()
    {
      using (var context = new BreakAwayContext())
      {
        var query = from d in context.Destinations
                    where d.Country == "Australia"
                    select d;

        query.Load();
        var count = context.Destinations.Local.Count;
        Console.WriteLine("Aussie destinations in memory: {0}", count);

        var query2 = from d in context.Destinations
                     where d.Country == "USA"
                    select d;

        query2.Load();
        var count2 = context.Destinations.Local.Count;
        Console.WriteLine("USA destinations in memory: {0}", count2);

          //Using Load on a LINQ query will bring the results of that query into memory but it does not remove the results of previous queries.
          //For example if you called Load on a query for Australian destinations and then Loan on a query for American destinations, both Australian and American
          //destinations would be in memory and would be returned from Local. (27)
      }
    }

    /*
     Querying against DbSet uses LINQ to Entities, which is specific to Entity Framework
    and uses your model and mapping to turn your query into SQL that is executed
    in the database. However, querying against Local uses LINQ to Objects, which performs
    filtering, sorting, and similar operations in memory using the standard .NET
    operators for testing equality, determining ordering, and the like.
     */
    private static void LocalLinqQueries()
    {
      using (var context = new BreakAwayContext())
      {
        context.Destinations.Load();

        var sortedDestinations = from d in context.Destinations.Local
                                 orderby d.Name
                                 select d;

        Console.WriteLine("All Destinations:");
        foreach (var destination in sortedDestinations)
        {
          Console.WriteLine(destination.Name);
        }

        var aussieDestinations = from d in context.Destinations.Local
                                 where d.Country == "Australia"
                                 select d;

        Console.WriteLine();
        Console.WriteLine("Australian Destinations:");
        foreach (var destination in aussieDestinations)
        {
          Console.WriteLine(destination.Name);
        }
      }
    }

    private static void ListenToLocalChanges()
    {
      using (var context = new BreakAwayContext())
      {//Local will raise the CollectionChanged event whenever the contents of Local change.
        context.Destinations.Local.CollectionChanged += (sender, args) =>
        {
          if (args.NewItems != null)
          {
            foreach (Destination item in args.NewItems)
            {
              Console.WriteLine("Added: " + item.Name);
            }
          }

          if (args.OldItems != null)
          {
            foreach (Destination item in args.OldItems)
            {
              Console.WriteLine("Removed: " + item.Name);
            }
          }
        };

        context.Destinations.Load();
      }
    }

    /*
     you might load fifty Destinations and then access the Lodgings property on each. That
would result in 51 queries against the database—one query to get the Destinations and
then for each of the fifty Destinations, to load that Destination’s Lodgings.
     */
    private static void TestLazyLoading()
    {
        //To disable Lazy Loading: DbContext.Configuration.LazyLoadingEnabled
      using (var context = new BreakAwayContext())
      {
        var query = from d in context.Destinations
                    where d.Name == "Grand Canyon"
                    select d;

        var canyon = query.Single();

        Console.WriteLine("Grand Canyon Lodging:");
        if (canyon.Lodgings != null)
        {
          foreach (var lodging in canyon.Lodgings)
          {
            Console.WriteLine(lodging.Name);
          }
        }
      }
    }

    /*
     Eager loading is currently only able to include the entire contents of a navigation property.
     * If you need a significant amount of related data, multiple simpler queries will
often be significantly faster than one big query that returns all the data.
     */
    private static void TestEagerLoading()
    {
      using (var context = new BreakAwayContext())
      {
        var allDestinations = context.Destinations.Include(d => d.Lodgings);/*use 'Include' method.*/
        //context.Destinations.Include(d => d.Lodgings.Select(l => l.PrimaryContact))
        //context.Lodgings.Include(l => l.PrimaryContact).Include(l => l.SecondaryContact)

        foreach (var destination in allDestinations)
        {
          Console.WriteLine(destination.Name);

          foreach (var lodging in destination.Lodgings)
          {
            Console.WriteLine(" - " + lodging.Name);
          }
        }
      }
    }

    /*Use Entry(); Collection(); Reference(); Load();*/ 
    private static void TestExplicitLoading()
    {
      using (var context = new BreakAwayContext())
      {
        var query = from d in context.Destinations
                    where d.Name == "Grand Canyon"
                    select d;

        var canyon = query.Single();

        context.Entry(canyon)//The Entry method gives you access to all the information that the DbContext has about an entity. (P37)
          .Collection(d => d.Lodgings)
          .Load();/*Once we have the entry for a given entity we can use the Collection and Reference
methods to drill into the information and operations for navigation properties. One of
the operations available is the Load method, which will send a query to the database to
load the contents of the navigation property.*/
        /*Finally, the Load method is used to query for the related data and bring it into memory.*/
        Console.WriteLine("Grand Canyon Lodging:");
        foreach (var lodging in canyon.Lodgings)
        {
          Console.WriteLine(lodging.Name);
        }
      }
    }

    private static void TestIsLoaded()
    {
      using (var context = new BreakAwayContext())
      {
        var canyon = (from d in context.Destinations
                      where d.Name == "Grand Canyon"
                      select d).Single();

        var entry = context.Entry(canyon);

        Console.WriteLine("Before Load: {0}", entry.Collection(d => d.Lodgings).IsLoaded);

        entry.Collection(d => d.Lodgings).Load();
        Console.WriteLine("After Load: {0}", entry.Collection(d => d.Lodgings).IsLoaded);
      }
    }

    private static void QueryLodgingDistance()
    {
      using (var context = new BreakAwayContext())
      {
        var canyonQuery = from d in context.Destinations
                          where d.Name == "Grand Canyon"
                          select d;

        var canyon = canyonQuery.Single();

        var lodgingQuery = context.Entry(canyon)
          .Collection(d => d.Lodgings)
          .Query();

        var distanceQuery = from l in lodgingQuery
                            where l.MilesFromNearestAirport <= 10
                            select l;

        foreach (var lodging in distanceQuery)
        {
          Console.WriteLine(lodging.Name);
        }
      }
    }

    /*if you are only interested in a subset of the contents,
    it may make sense to just bring the bits you are interested in into memory.*/
    private static void QueryLodgingCount()
    {
      using (var context = new BreakAwayContext())
      {
        var canyonQuery = from d in context.Destinations
                          where d.Name == "Grand Canyon"
                          select d;

        var canyon = canyonQuery.Single();

        var lodgingQuery = context.Entry(canyon)//It will not load everything into memory. It is like IQueriable instead of IEnumerable.
          .Collection(d => d.Lodgings)
          .Query();//to create a LINQ to Entities query for the Lodgings associated with the Grand Canyon. Because it is a LINQ query, 
          //you can then do further filtering, sorting, aggregation, and the like.

        var lodgingCount = lodgingQuery.Count();//then uses the LINQ Count method to materialize just the count of the rersults of the query. Only the single result is returned from database.
        Console.WriteLine("Lodging at Grand Canyon: " + lodgingCount);

          /*Write everything together:
           
            context.Entry(canyon)
            .Collection(d => d.Lodgings)
            .Query()
            .Where(l => l.Name.Contains("Hotel"))
            .Load();
           
           */
      }
    }
  }
}
