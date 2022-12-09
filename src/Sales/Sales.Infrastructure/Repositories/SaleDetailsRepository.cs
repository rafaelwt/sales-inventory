using Dapper;
using Sales.Application.Interfaces.IRepositories;
using Sales.Domain.Models;
using Sales.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repositories
{
    public class SaleDetailsRepository: ISaleDetailsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SaleDetailsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<SaleDetails> InsertAsync(SaleDetails saleDetails)
        {
            using var connection = this._applicationDbContext.CreateConnection();
            string sql = @"
                INSERT  INTO sales_details
                    (sales_id, product_id, price_per_unit, quantity_sold, iva_amount)
                VALUES 
                    (@sales_id, @product_id, @price_per_unit, @quantity_sold, @iva_amount);
                SELECT LAST_INSERT_ID();";
            saleDetails.id = await connection.ExecuteScalarAsync<int>(sql, saleDetails);
            return saleDetails;
        }

        public async Task<SaleDetails> UpdateAsync(SaleDetails saleDetails)
        {
            var sql = "UPDATE sales_details SET total_amount = @total_amount, sub_total_amount = @sub_total_amount, iva_amount = @iva_amount  WHERE id = @id";
            using var connection = this._applicationDbContext.CreateConnection();
            connection.Open();
            var result = await connection.ExecuteAsync(sql, saleDetails);
            return saleDetails;
        }
        public async Task<SaleDetails> GetAsync(int id)
        {
            var sql = "SELECT * FROM sales_details WHERE id = @id";
            using var connection = this._applicationDbContext.CreateConnection();
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<SaleDetails>(sql, new { id });
            return result;
        }

        public async Task<IEnumerable<SaleDetails>> GetAllAsync()
        {
            using var connection = this._applicationDbContext.CreateConnection();
            return await connection.QueryAsync<SaleDetails>("SELECT * FROM sales_details");
        }
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "UPDATE FROM sales_details SET state_id = 2 WHERE id = @id";
            using var connection = this._applicationDbContext.CreateConnection();
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { id });
            return result;
        }
    }

}
