using System.Data;
using LoanApp.Data.Enums;
using LoanApp.Data.Models;
using LoanApp.Helpers;
using LoanApp.Repositories.Interfaces;

namespace LoanApp.Repositories.Repositories
{
	public class LoanRepository : ILoanRepository
	{
		private readonly IDatabaseRepository _databaseRepository;
		private readonly IFieldInfoRepository _fieldInfoRepository;
		private readonly ITableInfoRepository _tableInfoRepository;
		public LoanRepository(IDatabaseRepository databaseRepository,
							  IFieldInfoRepository fieldInfoRepository,
							  ITableInfoRepository tableInfoRepository)
		{
			_databaseRepository = databaseRepository;
			_fieldInfoRepository = fieldInfoRepository;
			_tableInfoRepository = tableInfoRepository;
		}
		public async Task<Loan> GetLoan(int id)
		{
			var tableInfos = await _tableInfoRepository.GetTableInfo((int)TableType.Loans);
			var fieldInfos = await _fieldInfoRepository.GetFieldsInfo(tableInfos.Id);
			var columns = string.Join(",", fieldInfos.Select(x => x.FieldName));
			var sqlScriptGenerator = new SqlScriptGenerator();

			if (string.IsNullOrEmpty(columns) || string.IsNullOrEmpty(tableInfos?.TableName))
			{
				return new Loan();
			}

			var sqlQuery = sqlScriptGenerator.SelectQueryBuilder(columns, tableInfos.TableName, $"id = {id}");

			return await _databaseRepository.ExecuteAsyncReturnSingle<Loan>(sqlQuery, null, CommandType.Text);

		}

		public async Task<IEnumerable<Loan>> GetLoans()
		{
			throw new NotImplementedException();
		}
	}
}
