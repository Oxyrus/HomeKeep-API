using System.Data;
using Dapper;
using HomeKeep.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace HomeKeep.Infrastructure.Persistence;

public class PostgreSqlQueryRunner : IQueryRunner
{
    private readonly string _connectionString;

    public PostgreSqlQueryRunner(IConfiguration configuration)
    {
        _connectionString = configuration.GetSection("ConnectionStrings:Default").Value;
    }

    public async Task<IEnumerable<T>> QueryMultipleAsync<T>(string sql, object? parameters = null)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<T>(sql, parameters);
    }

    public async Task<T> QueryAsync<T>(string sql, object? parameters = null)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
    }

    public async Task<IEnumerable<T>> QueryMultipleUsingStoredProcedureAsync<T>(
        string storedProcedureName,
        object? parameters = null)
    {
        await using var connection = new NpgsqlConnection(_connectionString);

        return await connection.QueryAsync<T>(
            storedProcedureName,
            parameters,
            commandType: CommandType.StoredProcedure);
    }
}