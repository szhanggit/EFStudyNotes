using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trycodefirst.Abstract;
using trycodefirst.Concrete;
using trycodefirst.Entities;

namespace trycodefirst
{
    class Program
    {
        static void Main(string[] args)
        {
            int page = 1;
            int PageSize = 5;

            IProductRepository repository = new EFProductRepository();
            IEnumerable<Product> products = repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);
            int length = products.Count();
        }
    }
}
