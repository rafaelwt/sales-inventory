using MediatR;
using Products.Application.Interfaces.IRepositories;
using Products.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Commands
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public string? name { get; set; }
        public decimal price { get; set; }
        public decimal cost { get; set; }
        public int stock { get; set; }
    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                name = request.name,
                price = request.price,
                cost = request.cost,
                stock = request.stock,
            };
            return await _productRepository.UpdateAsync(product);
        }
    }
}
