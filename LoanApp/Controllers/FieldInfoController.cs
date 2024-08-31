using LoanApp.Data.Models;
using LoanApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.WebApi.Controllers
{
	[Route("api/field-info")]
	[ApiController]
	public class FieldInfoController : ControllerBase
	{
		private readonly IFieldInfoService _fieldInfoService;

		public FieldInfoController(IFieldInfoService fieldInfoService)
		{
			_fieldInfoService = fieldInfoService;
		}

		[HttpGet]
		[Route("item/{id}")]
		public async Task<FieldInfo> GetFieldInfo(int id)
		{
			var result = await _fieldInfoService.GetFieldInfo(id);

			return result;
		}

		[HttpGet]
		[Route("items/{tableId}")]
		public async Task<IEnumerable<FieldInfo>> GetFieldItemsByTableId(int tableId)
		{
			var result = await _fieldInfoService.GetFieldsInfo(tableId);

			return result;
		}
	}
}
