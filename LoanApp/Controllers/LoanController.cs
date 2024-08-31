using LoanApp.Data.Models;
using LoanApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Controllers
{
	[Route("api/loan")]
	[ApiController]
	public class LoanController : ControllerBase
	{
		private readonly ILoanService _loanService;

		public LoanController(ILoanService loanService)
		{
			_loanService = loanService;
		}
		[HttpGet]
		[Route("{id}")]
		public async Task<Loan> GetLoan(int id)
		{
			return await _loanService.GetLoan(id);
		}
	}
}
