using Dapper;
using System.Data;

namespace LoanApp.Repositories.Interfaces
{
	public interface IDatabaseRepository
	{
		Task ExecuteAsyncWithoutReturn(string procedureName,
									   DynamicParameters parameters,
									   CommandType commandType = CommandType.StoredProcedure);

		Task<T> ExecuteAsyncReturnScalar<T>(string procedureName,
											DynamicParameters parameters,
											CommandType commandType = CommandType.StoredProcedure);

		Task<IEnumerable<T>> ExecuteAsyncReturnList<T>(string procedureName,
													   DynamicParameters? parameters,
													   CommandType commandType = CommandType.StoredProcedure);

		Task<IEnumerable<T>> ExecuteAsyncReturnDynamicList<T>(string procedureName,
															  DynamicParameters? parameters,
															  CommandType commandType = CommandType.StoredProcedure);

		void ExecuteWithoutReturn(string procedureName,
								  DynamicParameters? parameters,
								  CommandType commandType = CommandType.StoredProcedure);

		T ExecuteReturnScalar<T>(string procedureName,
								 DynamicParameters parameters,
								 CommandType commandType = CommandType.StoredProcedure);

		IEnumerable<T> ExecuteReturnList<T>(string procedureName,
											DynamicParameters parameters,
											CommandType commandType = CommandType.StoredProcedure);

		T ExecuteReturnSingle<T>(string procedureName,
								 DynamicParameters? parameters,
								 CommandType commandType = CommandType.StoredProcedure);

		Task<T> ExecuteAsyncReturnSingle<T>(string procedureName,
											DynamicParameters? parameters,
											CommandType commandType = CommandType.StoredProcedure);
	}
}
