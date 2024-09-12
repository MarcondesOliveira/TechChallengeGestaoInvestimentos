using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Queries.GetPortfoliosListWithAssets
{
    public class PortfolioAssetListVm
    {
        public Guid PortfolioId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<PortfolioAssetDto>? Assets { get; set; }
    }
}