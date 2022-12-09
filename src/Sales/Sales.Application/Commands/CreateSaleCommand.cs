using MediatR;
using Sales.Application.Dto;
using Sales.Application.Helpers;
using Sales.Application.Interfaces.IRepositories;
using Sales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Commands
{
 
    public class CreateSaleCommand : IRequest
    {

        public decimal sub_total { get; set; }
        public List<DetailsDto>? details { get; set; }
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateSaleCommand>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleDetailsRepository _saleDetailsRepository;

        public CreateProductCommandHandler(ISaleRepository saleRepository, ISaleDetailsRepository saleDetailsRepository)
        {
            _saleRepository= saleRepository;
            _saleDetailsRepository= saleDetailsRepository;
        }
        public async Task<Unit> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var iva = Tax.CalculateTaxIva(request.sub_total);
            var newSale = new Sale
            {
                total_amount = request.sub_total + iva,
                sub_total_amount = request.sub_total,
                iva_amount = iva,

            };
            // TODO: SE TIENE QUE VALIDAR QUE EL MONTO TOTAL COINCIDA CON EL DETALLE Y LOS MONTOS DE LOS PRODUCTOS EN LA DB
            var sale =  await _saleRepository.InsertAsync(newSale);
            request.details!.ForEach(async item =>
            {
                var newDetails = new SaleDetails
                {
                    sales_id = sale.id,
                    product_id= item.product_id,
                    quantity_sold = item.quantity
                    
                };
                await _saleDetailsRepository.InsertAsync(newDetails);
            });
            
            return Unit.Value;
      
        }
    }
}
