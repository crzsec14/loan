using LoanApp.Data.Models;

namespace LoanApp.Services.Interfaces
{
	public interface ILoanService
	{
		Task<Loan> GetLoan(int id);
	}
}
