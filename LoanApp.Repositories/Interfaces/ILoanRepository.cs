using LoanApp.Data.Models;

namespace LoanApp.Repositories.Interfaces
{
	public interface ILoanRepository
	{
		Task<Loan> GetLoan(int id);
		Task<IEnumerable<Loan>> GetLoans();
	}
}
