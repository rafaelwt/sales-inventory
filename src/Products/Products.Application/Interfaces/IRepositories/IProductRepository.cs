using Products.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Interfaces.IRepositories
{
    public interface  IProductRepository
    {
        public Task<Product> UpdateAsync(Product product);
        public Task<Product> InsertAsync(Product product);
        public Task<Product> GetAsync(int id);
        public Task<IEnumerable<Product>> GetAllAsync();
        public Task<int> DeleteAsync(int id);


    }
}
