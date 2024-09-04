using AutoMapper;
using FluentValidation;
using MediatR;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.CreatePortfolio
{
    public class CreatePortfolioCommandHandler : IRequestHandler<CreatePortfolioCommand, Guid>
    {
        private readonly IAsyncRepository<Portfolio> _portfolioRepository;
        private readonly IMapper _mapper;

        public CreatePortfolioCommandHandler(IAsyncRepository<Portfolio> portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePortfolioCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePortfolioCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var portfolio = _mapper.Map<Portfolio>(request);

            portfolio.Status = "A";

            portfolio.Id = Guid.NewGuid(); // Gera um novo GUID para o Portfolio
            portfolio = await _portfolioRepository.AddAsync(portfolio);

            return portfolio.Id;
        }
    }
}
