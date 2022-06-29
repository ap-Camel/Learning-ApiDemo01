namespace APIDEMO01.SQL{

    public interface ISqlDataAccess{
        string connectionStringName { get; set; }
        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
        Task<T> LoadSingle<T>(string sql);
        Task<List<T>> LoadMany<T>(string sql);
        Task<bool> insertData(string sql);
    }
}