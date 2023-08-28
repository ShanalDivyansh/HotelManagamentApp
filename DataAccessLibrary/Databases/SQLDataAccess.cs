using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary.Databases
{
	public class SQLDataAccess : ISQLDataAccess
	{
		private readonly IConfiguration _config;

		public SQLDataAccess(IConfiguration config)
		{
			_config = config;
		}
		public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionStringName, bool isStoredProcedure = false)
		{
			CommandType commandType = CommandType.Text;
			if (isStoredProcedure == true)
			{
				commandType = CommandType.StoredProcedure;
			}
			using (IDbConnection con = new SqlConnection(connectionStringName))
			{
				List<T> rows = con.Query<T>(sqlStatement, parameters, commandType: commandType).ToList();
				return rows;
			}
		}
		public void SaveData<T>(string sqlStatement, T parameters, string connectionStringName, bool isStoredProcedure = false)
		{
			CommandType commandType = CommandType.Text;
			if (isStoredProcedure == true)
			{
				commandType = CommandType.StoredProcedure;
			}
			using (IDbConnection con = new SqlConnection(connectionStringName))
			{
				con.Execute(sqlStatement, parameters, commandType: commandType);
			}
		}
	}
}
