using AutoMapper;
using Blazored.LocalStorage;
using TechChallengeGestaoInvestimentos.AppWebAssembly.Interfaces;
using TechChallengeGestaoInvestimentos.AppWebAssembly.Services.Base;
using TechChallengeGestaoInvestimentos.AppWebAssembly.ViewModels;

namespace TechChallengeGestaoInvestimentos.AppWebAssembly.Services
{
    public class TransactionDataService : BaseDataService, ITransactionDataService
    {
        private readonly IMapper _mapper;
        public TransactionDataService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<PagedTransactionForMonthViewModel> GetPagedTransactionForMonth(DateTime date, int page, int size)
        {
            var transactions = await _client.GetPagedTransactionsForMonthAsync(date, page, size);
            var mappedTransactions = _mapper.Map<PagedTransactionForMonthViewModel>(transactions);

            return mappedTransactions;
        }
    }
}
