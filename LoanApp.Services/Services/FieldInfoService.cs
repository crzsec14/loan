using LoanApp.Data.Models;
using LoanApp.Repositories.Interfaces;
using LoanApp.Services.Interfaces;

namespace LoanApp.Services.Services
{
	public class FieldInfoService : IFieldInfoService
	{
		private readonly IFieldInfoRepository _fieldInfoRepository;

		public FieldInfoService(IFieldInfoRepository fieldInfoRepository)
		{
			_fieldInfoRepository = fieldInfoRepository;
		}

		public async Task<FieldInfo> GetFieldInfo(int id)
		{
			try
			{
				return await _fieldInfoRepository.GetFieldInfo(id);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		public async Task<IEnumerable<FieldInfo>> GetFieldsInfo(int tableId)
		{
			try
			{
				return await _fieldInfoRepository.GetFieldsInfo(tableId);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}