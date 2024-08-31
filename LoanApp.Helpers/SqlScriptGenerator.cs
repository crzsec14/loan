namespace LoanApp.Helpers
{
	public class SqlScriptGenerator
	{
		public string SelectQueryBuilder(string columns, string tableName, string filter)
		{
			var sqlQuery = $"SELECT {columns} FROM {tableName}";

			return sqlQuery;
		}
	}
}
