using MediatR;
using Products.Application.Interfaces.IRepositories;
using Products.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Queries
{
    public class GetAllProductQuery : IRequest<IEnumerable<Product>>
    {
        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
        {
            private readonly IProductRepository _productRepository;

            public GetAllProductQueryHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<IEnumerable<Product>> Handle(GetAllProductQuery query, CancellationToken cancellationToken)
            {
                var productList = await _productRepository.GetAllAsync();
                return productList;
            }
        }
    }
}
