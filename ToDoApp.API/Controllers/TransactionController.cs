using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallengeGestaoInvestimentos.Application.Features.Transactions.Commands.CreateTransaction;

namespace TechChallengeGestaoInvestimentos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddTransaction")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTransactionCommand createTransactionCommand)
        {
            var id = await _mediator.Send(createTransactionCommand);
            return Ok(id);
        }
    }
}
