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

        public void AddProducts(Product product){
            using(var db = new NpgsqlConnection(connection))
            {
                var sqlQwer = "INSERT INTO product (id, name) VALUES(@id, @name)";
                db.Execute(sqlQwer, product);
            }
        }

        public void DeleteProducts(int productId){
            using(var db = new NpgsqlConnection(connection))
            {
                var sqlQwer = "DELETE FROM product WHERE id = @id";
                db.Execute(sqlQwer,  new { id = productId });
            }
        }

        public void SetProducts(Product product){
             using(var db = new NpgsqlConnection(connection))
            {
                var sqlQwer = "UPDATE product SET name = @name WHERE Id = @Id";
                db.Execute(sqlQwer,  product);
            }
        }
    }
}