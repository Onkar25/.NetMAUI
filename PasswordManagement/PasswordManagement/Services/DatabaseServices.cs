using PasswordManagement.Models;
using SQLite;

namespace PasswordManagement.Services;

public class DatabaseServices
{
    private const string DbName = "passMgmt.db";
    private readonly SQLiteAsyncConnection connection;

    public DatabaseServices()
    {
        connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory,DbName));
        connection.CreateTableAsync<StoredPassword>();
    }

    public async Task<List<StoredPassword>> GetStoredPasswordsAsync(){
        return await connection.Table<StoredPassword>().ToListAsync();
    }

    public async Task InsertPasswordData(StoredPassword password)
    {
        await connection.InsertAsync(password);
    }

    public async Task UpdatePasswordData(StoredPassword password)
    {
        await connection.UpdateAsync(password);
    }

     public async Task DeletePasswordData(StoredPassword password)
    {
        await connection.DeleteAsync(password);
    }
}
