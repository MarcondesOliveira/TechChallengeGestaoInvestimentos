using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.CreatePortfolio;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.DeletePortfolio;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Queries.GetPortfolioList;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Queries.GetPortfoliosListWithAssets;

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
        [Authorize]
        public async Task<ActionResult<List<PortfolioListVm>>> GetAllPortfolios()
        {
            var portfolios = await _mediator.Send(new GetPortfoliosListQuery());
            return Ok(portfolios);
        }

        [HttpGet("allwithassets", Name = "GetPortfoliosWithAssets")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize]
        public async Task<ActionResult<List<PortfolioAssetListVm>>> GetPortfolioWithAssets(bool includeHistory)
        {
            // Cria a query com o parâmetro includeHistory
            var getPortfoliosListWithAssetsQuery = new GetPortfoliosListWithAssetsQuery
            {
                IncludeHistory = includeHistory
            };

            // Envia a query via Mediator
            var dtos = await _mediator.Send(getPortfoliosListWithAssetsQuery);

            // Se nenhum portfólio for encontrado
            if (dtos == null || dtos.Count == 0)
            {
                return NotFound("No portfolios found with assets.");
            }

            return Ok(dtos);
        }

        [HttpPost(Name = "AddPortfolio")]
        [Authorize]
        public async Task<ActionResult<CreatePortfolioCommandResponse>> Create([FromBody] CreatePortfolioCommand createPortfolioCommand)
        {
            var response = await _mediator.Send(createPortfolioCommand);
            return Ok(response);
        }

        [HttpDelete("{id:guid}", Name = "DeletePortfolio")]
        [Authorize]
        public async Task<ActionResult> DeletePortfolio(Guid id)
        {
            await _mediator.Send(new DeletePortfolioCommand { PortfolioId = id });

            return NoContent();
        }
    }
}
