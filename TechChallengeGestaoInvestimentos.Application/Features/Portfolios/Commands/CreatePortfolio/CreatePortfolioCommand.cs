﻿using MediatR;

namespace TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.CreatePortfolio
{
    public class CreatePortfolioCommand : IRequest<CreatePortfolioCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
