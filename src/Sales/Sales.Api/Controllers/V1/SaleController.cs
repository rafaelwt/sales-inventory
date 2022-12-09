using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Application.Commands;

namespace Sales.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class SaleController : ControllerBase
    {
        private readonly ILogger<SaleController> _logger;
        private readonly IMediator _mediator;

        public SaleController(ILogger<SaleController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateSaleCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
