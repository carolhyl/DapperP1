using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DapperPractice1.Context
{
	public class DapperContext
	{
		private readonly IConfiguration _configuration;
        private readonly string _connectionString; 
        public DapperContext(IConfiguration config)
        {
            _configuration = config;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }


}

