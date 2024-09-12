using Microsoft.AspNetCore.Components;
using TechChallengeGestaoInvestimentos.App.Interfaces;
using TechChallengeGestaoInvestimentos.App.ViewModels;

namespace TechChallengeGestaoInvestimentos.App.Components.Pages
{
    public partial class Transactions
    {
        [Inject]
        public ITransactionDataService TransactionDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string SelectedMonth { get; set; }
        public string SelectedYear { get; set; }

        public List<string> MonthList { get; set; } = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        public List<string> YearList { get; set; } = new List<string>() { "2022", "2023", "2024" };
        private int? pageNumber = 1;

        private PaginatedList<TransactionsForMonthListViewModel> paginatedList
            = new PaginatedList<TransactionsForMonthListViewModel>();

        private IEnumerable<TransactionsForMonthListViewModel> transactionsList;

        protected async Task GetSales()
        {
            DateTime dt = new DateTime(int.Parse(SelectedYear), int.Parse(SelectedMonth), 1);

            var transactions = await TransactionDataService.GetPagedTransactionForMonth(dt, pageNumber.Value, 5);
            paginatedList = new PaginatedList<TransactionsForMonthListViewModel>(transactions.TransactionsForMonth.ToList(), transactions.Count, pageNumber.Value, 5);
            transactionsList = paginatedList.Items;

            StateHasChanged();
        }

        public async void PageIndexChanged(int newPageNumber)
        {
            if (newPageNumber < 1 || newPageNumber > paginatedList.TotalPages)
            {
                return;
            }
            pageNumber = newPageNumber;
            await GetSales();
            StateHasChanged();
        }
    }
}
