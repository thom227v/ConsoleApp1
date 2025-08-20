using DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class SqlProductRepository : IProductRepository
    {
        public List<string> GetAllProducts()
        {
           return new List<string>() { "pizza", "burger", "pasta" };
        }
        public void AddProduct(string name)
        {
            Console.WriteLine("Added {0} to the products", name);
        }
    }
}
