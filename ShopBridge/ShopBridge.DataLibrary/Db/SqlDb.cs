using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ShopBridge.DataLibrary.Db
{
    public class SqlDb : IDataAccess
    {
        private readonly IConfiguration _config;

        //Dependency Injuction depends on Interface
        public SqlDb(IConfiguration config)
        {
            _config = config;
        }

        //Async to communicate to database and not to be blocked by User
        //Interface Thread
        //Async is used to do threading ,If we are using threading use async
        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(storedProcedure, parameters,
                                                        commandType: CommandType.StoredProcedure);
                return rows.ToList();
            }
        }

        public async Task<int> SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return await connection.ExecuteAsync(storedProcedure, parameters,
                                                         commandType: CommandType.StoredProcedure);

            }
        }
    }
}
