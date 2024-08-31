using LoanApp.Data.Models;

namespace LoanApp.Repositories.Interfaces
{
	public interface IFieldInfoRepository
	{
		Task<FieldInfo> GetFieldInfo(int id);
		Task<IEnumerable<FieldInfo>> GetFieldsInfo(int tableId);
	}
}
