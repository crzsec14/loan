using System.Data;
using LoanApp.Data.Models;
using LoanApp.Repositories.Interfaces;

namespace LoanApp.Repositories.Repositories
{
	public class FieldInfoRepository : IFieldInfoRepository
	{
		private readonly IDatabaseRepository _databaseRepository;

		public FieldInfoRepository(IDatabaseRepository databaseRepository)
		{
			_databaseRepository = databaseRepository;
		}
		public async Task<FieldInfo> GetFieldInfo(int id)
		{
			if (id < 1) { 
				return new FieldInfo();
			}

			var sqlQuery = $"SELECT * FROM FieldInfos WHERE Id = {id}";

			return await _databaseRepository.ExecuteAsyncReturnSingle<FieldInfo>(sqlQuery, null, CommandType.Text);
		}

		public async Task<IEnumerable<FieldInfo>> GetFieldsInfo(int tableId)
		{
			if (tableId < 1)
			{
				return new List<FieldInfo>();
			}

			var sqlQuery = $"SELECT * FROM FieldInfos WHERE TableId = {tableId}";

			return await _databaseRepository.ExecuteAsyncReturnList<FieldInfo>(sqlQuery, null, CommandType.Text);
		}
	}
}
