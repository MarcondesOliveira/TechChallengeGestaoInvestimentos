using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechChallengeGestaoInvestimentos.Application.Features.Transactions.Commands.CreateTransaction;
using TechChallengeGestaoInvestimentos.Application.Features.Transactions.Queries.GetTransactionForMonth;

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

        [HttpGet("paged", Name = "GetPagedTransactionsForMonth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult<PagedTransactionsForMonthVm>> GetPagedTransactionsForMonth(DateTime date, int page, int size)
        {
            var getTransactionsForMonthQuery = new GetTransactionsForMonthQuery() { Date = date, Page = page, Size = size };
            var dtos = await _mediator.Send(getTransactionsForMonthQuery);

            return Ok(dtos);
        }

        //[HttpPost(Name = "AddTransaction")]
        //public async Task<ActionResult<Guid>> Create([FromBody] CreateTransactionCommand createTransactionCommand)
        //{
        //    var id = await _mediator.Send(createTransactionCommand);
        //    return Ok(id);
        //}
    }
}
