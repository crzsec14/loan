using LoanApp.Data.Models;

namespace LoanApp.Repositories.Interfaces
{
	public interface ITableInfoRepository
	{
		Task<TableInfo> GetTableInfo(int id);
		Task<TableInfo> GetTableInfoByName(string tableName);
	}
}
