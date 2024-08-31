using Dapper;
using System.Data;
using System.Data.SqlClient;
using LoanApp.Repositories.Interfaces;

namespace LoanApp.Repositories.Repositories
{
	public class DatabaseRepository : IDatabaseRepository
	{
		private readonly string _connectionString;

		public DatabaseRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public async Task<T> ExecuteAsyncReturnScalar<T>(string procedureName,
														 DynamicParameters parameters,
														 CommandType commandType = CommandType.StoredProcedure)
		{
			using (var sqlCon = new SqlConnection(_connectionString))
			{
				sqlCon.Open();

				return (T)Convert.ChangeType(await sqlCon.ExecuteScalarAsync(procedureName, parameters, commandType: commandType), typeof(T));
			}
		}

		public async Task ExecuteAsyncWithoutReturn(string procedureName,
													DynamicParameters parameters,
													CommandType commandType = CommandType.StoredProcedure)
		{
			using (var sqlCon = new SqlConnection(_connectionString))
			{
				sqlCon.Open();

				await sqlCon.ExecuteAsync(procedureName, parameters, commandType: commandType);
			}
		}

		public async Task<IEnumerable<T>> ExecuteAsyncReturnList<T>(string procedureName,
																	DynamicParameters parameters,
																	CommandType commandType = CommandType.StoredProcedure)
		{
			using (var sqlCon = new SqlConnection(_connectionString))
			{
				sqlCon.Open();
				var response = await sqlCon.QueryAsync<T>(procedureName, parameters, commandType: commandType);
				return response;
			}
		}

		public async Task<IEnumerable<T>> ExecuteAsyncReturnDynamicList<T>(string procedureName,
																	DynamicParameters? parameters,
																	CommandType commandType = CommandType.StoredProcedure)
		{
			await using var sqlCon = new SqlConnection(_connectionString);
			sqlCon.Open();
			var response = await sqlCon.QueryAsync<T>(procedureName, parameters, commandType: commandType);
			return response;
		}

		public T ExecuteReturnScalar<T>(string procedureName,
										DynamicParameters parameters,
										CommandType commandType = CommandType.StoredProcedure)
		{
			using (var sqlCon = new SqlConnection(_connectionString))
			{
				sqlCon.Open();

				return (T)Convert.ChangeType(sqlCon.ExecuteScalar(procedureName, parameters, commandType: commandType), typeof(T));
			}
		}

		public void ExecuteWithoutReturn(string procedureName,
										 DynamicParameters? parameters,
										 CommandType commandType = CommandType.StoredProcedure)
		{
			using (var sqlCon = new SqlConnection(_connectionString))
			{
				sqlCon.Open();

				sqlCon.Execute(procedureName, parameters, commandType: commandType);
			}
		}

		public IEnumerable<T> ExecuteReturnList<T>(string procedureName,
												   DynamicParameters parameters,
												   CommandType commandType = CommandType.StoredProcedure)
		{
			using (var sqlCon = new SqlConnection(_connectionString))
			{
				sqlCon.Open();

				return sqlCon.Query<T>(procedureName, parameters, commandType: commandType);
			}
		}

		public T ExecuteReturnSingle<T>(string procedureName,
										DynamicParameters? parameters,
										CommandType commandType = CommandType.StoredProcedure)
		{
			using (var sqlCon = new SqlConnection(_connectionString))
			{
				sqlCon.Open();

				return SqlMapper.QuerySingleOrDefault<T>(sqlCon, procedureName, parameters, commandType: commandType);
			}
		}

		public async Task<T> ExecuteAsyncReturnSingle<T>(string procedureName,
														 DynamicParameters? parameters,
														 CommandType commandType = CommandType.StoredProcedure)
		{
			using (var sqlCon = new SqlConnection(_connectionString))
			{
				sqlCon.Open();

				return await SqlMapper.QuerySingleAsync<T>(sqlCon, procedureName, parameters, commandType: commandType);
			}
		}
	}
}
