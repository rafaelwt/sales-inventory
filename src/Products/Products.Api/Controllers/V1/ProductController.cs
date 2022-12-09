using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Commands;
using Products.Application.Queries;

namespace Products.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllProductQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
             return Ok(await _mediator.Send(new GetProductByIdQuery { id = id}));
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateProductCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateProductCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
