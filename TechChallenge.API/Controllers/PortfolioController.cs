using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.CreatePortfolio;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.DeletePortfolio;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Queries.GetPortfolioList;

namespace TechChallengeGestaoInvestimentos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController : Controller
    {
        private readonly IMediator _mediator;

        public PortfolioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllPortfolios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PortfolioListVm>>> GetAllPortfolios()
        {
            var portfolios = await _mediator.Send(new GetPortfoliosListQuery());
            return Ok(portfolios);
        }


        [HttpPost(Name = "AddPortfolio")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePortfolioCommand createPortfolioCommand)
        {
            var id = await _mediator.Send(createPortfolioCommand);
            return Ok(id);
        }

        [HttpDelete("{id:guid}", Name = "DeletePortfolio")]
        public async Task<ActionResult> DeletePortfolio(Guid id)
        {
            await _mediator.Send(new DeletePortfolioCommand { PortfolioId = id });

            return NoContent();
        }
    }
}
