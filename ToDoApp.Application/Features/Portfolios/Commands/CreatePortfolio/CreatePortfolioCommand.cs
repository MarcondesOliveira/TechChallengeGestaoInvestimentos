﻿using MediatR;

namespace TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.CreatePortfolio
{
    public class CreatePortfolioCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
