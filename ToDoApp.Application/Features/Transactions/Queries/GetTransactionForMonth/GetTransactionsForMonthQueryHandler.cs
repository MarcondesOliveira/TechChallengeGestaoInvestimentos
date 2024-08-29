using AutoMapper;
using MediatR;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Application.Features.Transactions.Queries.GetTransactionForMonth
{
    public class GetTransactionsForMonthQueryHandler : IRequestHandler<GetTransactionsForMonthQuery, PagedTransactionsForMonthVm>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionsForMonthQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<PagedTransactionsForMonthVm> Handle(GetTransactionsForMonthQuery request, CancellationToken cancellationToken)
        {
            var list = await _transactionRepository.GetPagedTransactionsForMonth(request.Date, request.Page, request.Size);
            var transactions = _mapper.Map<List<TransactionsForMonthDto>>(list);

            var count = await _transactionRepository.GetTotalCountofTransactionsForMonth(request.Date);

            return new PagedTransactionsForMonthVm() { Count = count, TransactionsForMonth = transactions, Page = request.Page, Size = request.Size };
        }
    }
}
