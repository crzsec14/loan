

using LoanApp.Data.Models;

namespace LoanApp.Services.Interfaces
{
	public interface IFieldInfoService
	{
		Task<FieldInfo> GetFieldInfo(int id);
		Task<IEnumerable<FieldInfo>> GetFieldsInfo(int tableId);
	}
}
