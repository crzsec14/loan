using System.Data;
using LoanApp.Data.Models;
using LoanApp.Repositories.Interfaces;

namespace LoanApp.Repositories.Repositories
{
	public class TableInfoRepository : ITableInfoRepository
	{
		private readonly IDatabaseRepository _databaseRepository;

		public TableInfoRepository(IDatabaseRepository databaseRepository)
		{
			_databaseRepository = databaseRepository;
		}

		public async Task<TableInfo> GetTableInfo(int id)
		{
			if (id < 1)
			{
				return new TableInfo();
			}

			var sqlQuery = $"SELECT * FROM TableInfos WHERE Id = {id}";

			return await _databaseRepository.ExecuteAsyncReturnSingle<TableInfo>(sqlQuery, null, CommandType.Text);
		}

		public async Task<TableInfo> GetTableInfoByName(string tableName)
		{
			throw new NotImplementedException();
		}
	}
}
