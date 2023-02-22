namespace DataAccess.DbAccess;
public interface ISqlDataAccess
{
    // This is useful because this doesn't care about what is behind, and how its being done, it can be mssql mongodb or whatever
    // The other project doesn't know how it works the data access
    Task<IEnumerable<T>> LoadData<T, U>(string storeProcedure, U parameters, string connectionId = "Default");
    Task SaveData<T>(string storeProcedure, T paramaters, string connectionId = "Default");
}
