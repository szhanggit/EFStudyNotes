using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trycodefirst.Entities;

namespace trycodefirst.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
