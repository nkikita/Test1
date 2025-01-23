using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using Test1.Models;

namespace Test1.Services
{
    public class ProductService : IProductService
    {
        string connection = "Host=localhost;Port=5432;Database=DEMO;Username=postgres;Password=nikitos";
        public List<Product> GetProducts(){
            using(var db = new NpgsqlConnection(connection))
            {
                return db.Query<Product>("SELECT id, name FROM public.product").ToList<Product>();
            }
        }
    }
}