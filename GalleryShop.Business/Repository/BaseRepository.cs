using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace GalleryShop.Business.Repository
{
    public abstract class BaseRepository
    {
        protected readonly string ConnectionString;

        protected BaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Don't check use in tTransaction, this always casts returned IDs into <see cref="int"/>!!!
        /// </summary>
        protected async Task<int> InsertItemAsync(string sql, object dynamicParams)
        {
            var parameters = new DynamicParameters(dynamicParams);
            parameters.Add("ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("RetVal", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
                var errCode = parameters.Get<int>("ErrorCode");
                if (errCode != 0)
                {
                    throw new Exception(string.Format("InsertItem:{1}, Error:{0}", errCode, sql));
                }
                return parameters.Get<int>("RetVal");
            }
        }

        protected async Task<IEnumerable<T>> QueryItemsSimpleAsync<T>(string sql, object dynamicParams = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                //the query must be awaited, in order to run before the connection is disposed
                return await conn
                    .QueryAsync<T>(sql, dynamicParams, commandType: commandType)
                    .ConfigureAwait(false);
            }
        }

        protected async Task<T> QueryItemSimpleAsync<T>(string sql, CommandType commandType)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                //the query must be awaited, in order to run before the connection is disposed
                return await conn
                    .QueryFirstOrDefaultAsync<T>(sql, commandType: commandType)
                    .ConfigureAwait(false);
            }
        }

        protected async Task<T> QueryItemSimpleAsync<T>(string sql, object dynamicParams)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                //the query must be awaited, in order to run before the connection is disposed
                return await conn
                    .QueryFirstOrDefaultAsync<T>(sql, dynamicParams, commandType: CommandType.StoredProcedure)
                    .ConfigureAwait(false);
            }
        }

        protected async Task<T> QueryItemSimpleAsync<T>(string sql, object dynamicParams, CommandType commandType)
        {
            var parameters = new DynamicParameters(dynamicParams);
            using (var conn = new SqlConnection(ConnectionString))
            {
                //the query must be awaited, in order to run before the connection is disposed
                return await conn
                    .QueryFirstOrDefaultAsync<T>(sql, parameters, commandType: commandType)
                    .ConfigureAwait(false);
            }
        }

        protected async Task<int> ExecuteScalar(string sql, DynamicParameters parameters)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                //the query must be awaited, in order to run before the connection is disposed
                return await conn.ExecuteScalarAsync<int>(sql, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}