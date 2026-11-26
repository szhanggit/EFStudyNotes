using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trycodefirst.Abstract;
using trycodefirst.Entities;

namespace trycodefirst.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
