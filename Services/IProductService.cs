using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test1.Models;

namespace Test1.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProducts();
        public void AddProducts(Product product);
        public void SetProducts(Product product);
        public void DeleteProducts(int id);
       
    }


}