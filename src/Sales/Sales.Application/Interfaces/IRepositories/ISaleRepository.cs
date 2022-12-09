using Sales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Interfaces.IRepositories
{
    public interface ISaleRepository
    {
        public Task<Sale> UpdateAsync(Sale sale);
        public Task<Sale> InsertAsync(Sale Sale);
        public Task<Sale> GetAsync(int id);
        public Task<IEnumerable<Sale>> GetAllAsync();
        public Task<int> DeleteAsync(int id);
    }
}
