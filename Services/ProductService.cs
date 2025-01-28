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
        readonly string _connectionString;

        public ProductService (string connectionString){
            _connectionString = connectionString;
        }
        public List<Product> GetProducts(){
            using(var db = new NpgsqlConnection(_connectionString))
            {
                return db.Query<Product>("SELECT id, name FROM public.product").ToList<Product>();
            }
        }

        public void AddProducts(Product product){
            using(var db = new NpgsqlConnection(_connectionString))
            {
                var sqlQwer = "INSERT INTO product (name) VALUES(@name) RETURNING id;";

                int userid = db.Query<int>(sqlQwer,product).FirstOrDefault();
                product.id = userid;
            }
        }

        public void DeleteProducts(int productId){
            using(var db = new NpgsqlConnection(_connectionString))
            {
                var sqlQwer = "DELETE FROM product WHERE id = @id";
                db.Execute(sqlQwer,  new { id = productId });
            }
        }

        public void SetProducts(Product product){
             using(var db = new NpgsqlConnection(_connectionString))
            {
                var sqlQwer = "UPDATE product SET name = @name WHERE Id = @Id";
                db.Execute(sqlQwer,  product);
            }
        }
    }
}