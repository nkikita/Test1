using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test1.Models;

namespace Test1.Services
{
    public interface IProviderSevice
    {
        
        public Task<IEnumerable<Provider>> GetProvider();
        public void AddProvider(Provider product);
        public void SetProvider(Provider product);
        public void DeleteProvider(int id);
       
    }
}