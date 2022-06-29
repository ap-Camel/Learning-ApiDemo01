using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace APIDEMO01.SQL {

    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public string connectionStringName {get; set;} = "Default";

        public SqlDataAccess(IConfiguration config) {
            _config = config;
        }

        public async Task<bool> insertData(string sql)
        {
            
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.ExecuteAsync(sql);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);

                return data.ToList();
            }
        }

        public async Task<List<T>> LoadMany<T>(string sql)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var list = await connection.QueryAsync<T>(sql);
                    return list.ToList();
                }
                catch (Exception e)
                {
                    return new List<T>();
                }
            }
        }

        public async Task<T> LoadSingle<T>(string sql)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);
            T data = default(T);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    data = await connection.QuerySingleAsync<T>(sql);
                    return data;
                } catch(Exception e)
                {
                    return data;
                }
            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}