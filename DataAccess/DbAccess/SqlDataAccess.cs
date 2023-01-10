using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DbAccess;
// Generic iface to talk to sql trough dapper
public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _configuration;
    // _ private variables that come from DI
    public SqlDataAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // Default is the one from appseting.json
    // Runs a store procedure which has some parameters and returns that rows in an IEnumerable
    public async Task<IEnumerable<T>> LoadData<T, U>(string storeProcedure,
                                                    U paramaters,
                                                    string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));
        return await connection.QueryAsync<T>(storeProcedure, paramaters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storeProcedure,
                                                    T paramaters,
                                                    string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));
        await connection.ExecuteAsync(storeProcedure, paramaters, commandType: CommandType.StoredProcedure);
    }
}

