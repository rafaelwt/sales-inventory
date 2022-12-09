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

    public class GetProductByIdQuery : IRequest<Product>
    {
        public int id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery,Product>
        {
            private readonly IProductRepository _productRepository;

            public GetProductByIdQueryHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var productList = await _productRepository.GetAsync(query.id);
                return productList;
            }
        }
    }
}
