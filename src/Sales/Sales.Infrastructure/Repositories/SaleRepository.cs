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
    public class SaleRepository: ISaleRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SaleRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Sale> InsertAsync(Sale sale)
        {
            using (var connection = this._applicationDbContext.CreateConnection())
            {
                string sql = @"
                INSERT  INTO sales
                    (total_amount, sub_total_amount, iva_amount, sale_status_id)
                VALUES 
                    (@total_amount, @sub_total_amount, @iva_amount, 1);
                SELECT LAST_INSERT_ID();";
                sale.id = await connection.ExecuteScalarAsync<int>(sql, sale);
                return sale;

            }
        }

        public async Task<Sale> UpdateAsync(Sale sale)
        {
            var sql = "UPDATE sales SET total_amount = @total_amount, sub_total_amount = @sub_total_amount, iva_amount = @iva_amount  WHERE id = @id";
            using (var connection = this._applicationDbContext.CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, sale);
                return sale;
            }
        }
        public async Task<Sale> GetAsync(int id)
        {
            var sql = "SELECT * FROM sales WHERE id = @id";
            using (var connection = this._applicationDbContext.CreateConnection())
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Sale>(sql, new { id });
                return result;
            }
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            using (var connection = this._applicationDbContext.CreateConnection())
            {
                return await connection.QueryAsync<Sale>("SELECT * FROM sales");
            }
        }
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "UPDATE FROM sales SET state_id = 2 WHERE id = @id";
            using (var connection = this._applicationDbContext.CreateConnection())
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { id });
                return result;
            }
        }
    }
}
