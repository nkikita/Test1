using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using Test1.Models;

namespace Test1.Services
{
    public class ProviderService : IProviderSevice
    {
          readonly string _connectionString;

        public ProviderService (string connectionString){
            _connectionString = connectionString;
        }
        public async Task<IEnumerable<Provider>> GetProvider(){
            using(var db = new NpgsqlConnection(_connectionString))
            {
                var qwer = await db.QueryAsync<Provider>("SELECT id, name, inn, product_id FROM public.provider");
                return  qwer.ToList(); 
            }
        }

        public void AddProvider(Provider provider){
            using(var db = new NpgsqlConnection(_connectionString))
            {
                var sqlQwer = "INSERT INTO provider (name, inn, product_id) VALUES(@name, @inn, @product_id) RETURNING id;";

                int userid = db.Query<int>(sqlQwer,provider).FirstOrDefault();
                provider.id = userid;
            }
        }

        public void DeleteProvider(int providerId){
            using(var db = new NpgsqlConnection(_connectionString))
            {
                var sqlQwer = "DELETE FROM provider WHERE id = @id";
                db.Execute(sqlQwer,  new { id = providerId });
            }
        }

        public void SetProvider(Provider provider){
             using(var db = new NpgsqlConnection(_connectionString))
            {
                var sqlQwer = "UPDATE provider SET name = @name WHERE Id = @Id";
                db.Execute(sqlQwer,  provider);
            }
        }
    }
}