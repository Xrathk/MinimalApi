namespace DataAccessLayer.DbAccess
{
    /// <summary>
    /// This interface handles database access for the minimal API (read & write operations) via the SQL Client.
    /// </summary>
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "AkisMinimalAPIDB");
        Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "AkisMinimalAPIDB");
    }
}