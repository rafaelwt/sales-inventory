using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Products.Application.Interfaces.IRepositories;
using Products.Domain.Models;
using Products.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Products.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Product> InsertAsync(Product product)
        {
            using var connection = this._applicationDbContext.CreateConnection();
            string sql = @"
                INSERT  INTO products
                    (name, price, cost, stock, state_id)
                VALUES 
                    (@name, @price, @cost, @stock, 1);
                SELECT LAST_INSERT_ID();";
            product.id = await connection.ExecuteScalarAsync<int>(sql, product);
            return product;
        }

        public async  Task<Product> UpdateAsync(Product product)
        {
            var sql = "UPDATE products SET name = @name, price = @price, cost = @cost, stock = @stock WHERE id = @id";
            using var connection = this._applicationDbContext.CreateConnection();
            connection.Open();
            var result = await connection.ExecuteAsync(sql, product);
            return product;
        }
        public async Task<Product> GetAsync(int id)
        {
            var sql = "SELECT * FROM products WHERE id = @id";
            using var connection = this._applicationDbContext.CreateConnection();
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { id });
            return result;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using var connection = this._applicationDbContext.CreateConnection();
            return await connection.QueryAsync<Product>("SELECT * FROM products WHERE state_id = 1");
        }
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "UPDATE FROM products SET state_id = 2 WHERE id = @id";
            using var connection = this._applicationDbContext.CreateConnection();
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { id });
            return result;
        }
    }
}
