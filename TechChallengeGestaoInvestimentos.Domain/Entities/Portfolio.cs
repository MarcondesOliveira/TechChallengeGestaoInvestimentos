﻿using Microsoft.AspNetCore.Identity;
using TechChallengeGestaoInvestimentos.Domain.Common;

namespace TechChallengeGestaoInvestimentos.Domain.Entities
{
    public class Portfolio //: Entity
    {
        public Guid? PortfolioId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; } = "A";
        public ICollection<Asset>? Assets { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}