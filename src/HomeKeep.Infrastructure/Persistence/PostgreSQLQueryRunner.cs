using Dapper;
using HomeKeep.Application.Common.Interfaces;
using Npgsql;

namespace HomeKeep.Infrastructure.Persistence;

public class PostgreSqlQueryRunner : IQueryRunner
{
    public async Task<IEnumerable<T>> QueryMultipleAsync<T>(string sql, object? parameters = null)
    {
        await using var connection = new NpgsqlConnection(string.Empty);
        return await connection.QueryAsync<T>(sql, parameters);
    }

    public async Task<T> QueryAsync<T>(string sql, object? parameters = null)
    {
        await using var connection = new NpgsqlConnection(string.Empty);
        return await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
    }
}