namespace HomeKeep.Application.Common.Interfaces;

public interface IQueryRunner
{
    /// <summary>
    /// Returns a list of items of the designed type T
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task<IEnumerable<T>> QueryMultipleAsync<T>(string sql, object? parameters = null);

    /// <summary>
    /// Returns a single object of the designed type T
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task<T> QueryAsync<T>(string sql, object? parameters = null);

    /// <summary>
    /// Returns a list of items of the designed type T after executing an stored procedure
    /// </summary>
    /// <param name="storedProcedureName"></param>
    /// <param name="parameters"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task<IEnumerable<T>> QueryMultipleUsingStoredProcedureAsync<T>(
        string storedProcedureName,
        object? parameters = null);
}