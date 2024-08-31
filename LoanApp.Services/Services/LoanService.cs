using LoanApp.Data.Models;
using LoanApp.Repositories.Interfaces;
using LoanApp.Services.Interfaces;

namespace LoanApp.Services.Services
{
	public class LoanService : ILoanService
	{
		private readonly ILoanRepository _loanRepository;

		public LoanService(ILoanRepository loanRepository)
		{
			_loanRepository = loanRepository;
		}

		public async Task<Loan> GetLoan(int id)
		{
			try
			{
				return await _loanRepository.GetLoan(id);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}
