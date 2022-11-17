using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer.DbAccess.CustomMappers;

namespace DataAccessLayer.DbAccess
{
    /// <summary>
    /// This class handles database access for the minimal API (read & write operations) via the SQL Client.
    /// </summary>
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration config;

        /// <summary>
        /// Sql client constuctor.
        /// </summary>
        /// <param name="_config">App configuration</param>
        public SqlDataAccess(IConfiguration _config)
        {
            config = _config;

            // Adding custom type handlers
            SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());
        }

        /// <summary>
        /// Handles retrieving data from the database.
        /// </summary>
        /// <typeparam name="T">Type/model/table to look up</typeparam>
        /// <typeparam name="U">Parameters for search</typeparam>
        /// <param name="storedProcedure">The stored procedure to use for the search</param>
        /// <param name="parameters">Parameters that will be used in the search</param>
        /// <param name="connectionId">SQL server connection ID</param>
        /// <returns>The appropriate results</returns>
        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storedProcedure,
            U parameters,
            string connectionId = "AkisMinimalAPIDB")
        {
            // Get SQL client
            using IDbConnection connection = new SqlConnection(config.GetConnectionString(connectionId));

            // Return results based on search terms and parameters
            return await connection.QueryAsync<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);

        }

        /// <summary>
        /// Handles storing data to the database.
        /// </summary>
        /// <typeparam name="T">New database entries that must be stored</typeparam>
        /// <param name="storedProcedure">The stored procedure to use for the search</param>
        /// <param name="parameters">Parameters that will be used in the search</param>
        /// <param name="connectionId">SQL server connection ID</param>
        /// <returns>The appropriate results</returns>
        public async Task SaveData<T>(
            string storedProcedure,
            T parameters,
            string connectionId = "AkisMinimalAPIDB")
        {
            // Get SQL client
            using IDbConnection connection = new SqlConnection(config.GetConnectionString(connectionId));

            // Return results based on search terms and parameters
            await connection.ExecuteAsync(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);

        }

    }
}
