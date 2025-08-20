using DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<string> products;
        public InMemoryProductRepository()
        {
            products = new List<string>();
        }
        public List<string> GetAllProducts()
        {
            return products;
        }
        public void AddProduct(string name)
        {
            products.Add(name);
        }
    }
}
