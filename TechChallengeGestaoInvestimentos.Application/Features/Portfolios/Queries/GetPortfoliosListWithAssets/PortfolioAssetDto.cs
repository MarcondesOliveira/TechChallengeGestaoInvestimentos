using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Queries.GetPortfoliosListWithAssets
{
    public class PortfolioAssetDto
    {
        public Guid AssetId { get; set; }
        public string? Name { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public Guid PortfolioId { get; set; }
    }
}
