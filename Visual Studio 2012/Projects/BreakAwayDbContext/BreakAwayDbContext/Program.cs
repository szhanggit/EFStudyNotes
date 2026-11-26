using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakAwayDbContext
{
    class Program
    {
        static void Main(string[] args)
        {
            var allDestinations = GetDestinations();
            foreach (var destination in allDestinations)
            {
                Console.WriteLine(destination.Name);
            }

            Console.ReadKey();
        }

        public static List<Destination> GetDestinations()
        {
            using (var context = new BAEntities())
            { 
                var query = from d in context.Destinatinos
                            orderby d.Name
                            select d;
                return query.ToList();
            }
        }
    }
}
