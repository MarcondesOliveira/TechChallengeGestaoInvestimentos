using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechChallengeGestaoInvestimentos.Application.Features.Assets.Commands.CreateAsset;
using TechChallengeGestaoInvestimentos.Application.Features.Assets.Commands.UpdateAsset;
using TechChallengeGestaoInvestimentos.Application.Features.Assets.Queries.GetAssetDetail;
using TechChallengeGestaoInvestimentos.Application.Features.Assets.Queries.GetAssetList;

namespace TechChallengeGestaoInvestimentos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : Controller
    {
        private readonly IMediator _mediator;

        public AssetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllAssets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult<List<AssetListVm>>> GetAllAssets()
        {
            var result = await _mediator.Send(new GetAssetsListQuery());

            

            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetAssetById")]
        public async Task<ActionResult<AssetDetailVm>> GetAssetById(Guid id)
        {
            var getAssetDetailQuery = new GetAssetDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getAssetDetailQuery));
        }

        [HttpPost(Name = "AddAsset")]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAssetCommand createAssetCommand)
        {
            var id = await _mediator.Send(createAssetCommand);

            return Ok(id);
        }

        [HttpPut("{id:guid}/transaction", Name = "UpdateAssetTransaction")]
        [Authorize]
        public async Task<ActionResult> UpdateTransaction(Guid id, [FromBody] UpdateAssetTransactionCommand updateAssetTransactionCommand)
        {
            if (id != updateAssetTransactionCommand.AssetId)
            {
                return BadRequest("Asset ID mismatch");
            }

            await _mediator.Send(updateAssetTransactionCommand);

            return NoContent();
        }
    }
}
