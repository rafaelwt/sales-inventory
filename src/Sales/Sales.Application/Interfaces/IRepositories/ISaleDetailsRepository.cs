using Sales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Interfaces.IRepositories
{
    public  interface ISaleDetailsRepository
    {
        public Task<SaleDetails> UpdateAsync(SaleDetails saleDetails);
        public Task<SaleDetails> InsertAsync(SaleDetails saleDetails);
        public Task<SaleDetails> GetAsync(int id);
        public Task<IEnumerable<SaleDetails>> GetAllAsync();
        public Task<int> DeleteAsync(int id);
    }
}
