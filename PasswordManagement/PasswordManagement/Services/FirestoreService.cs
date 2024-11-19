using Google.Cloud.Firestore;
using PasswordManagement.Models;
namespace PasswordManagement.Services;
public class FirestoreService
{
    private FirestoreDb db;
    private async Task SetupFirestore()
    {
        if (db == null)
        {
            var stream = await FileSystem.OpenAppPackageFileAsync("admin-sdk.json");
            var reader = new StreamReader(stream);
            var contents = reader.ReadToEnd();

            db = new FirestoreDbBuilder
            {
                ProjectId = "maui-password-mgmt",

                ConverterRegistry = new ConverterRegistry
                {
                    new DateTimeToTimestampConverter(),
                },
                JsonCredentials = contents
            }.Build();
        }
    }
    public async Task<string> InsertPassword(StoredPassword sample)
    {
        await SetupFirestore();
        var data = await db.Collection("StoredPassword").AddAsync(sample);
        return data.Id;
    }

    public async Task RemovePassword(StoredPassword sample)
    {
        await SetupFirestore();
        var data = db.Collection("StoredPassword").Document(sample.DocId);
        await data.DeleteAsync();
    }

    public async Task UpdatePassword(StoredPassword sample)
    {
        await SetupFirestore();
        var data = db.Collection("StoredPassword").Document(sample.DocId);
        await data.UpdateAsync("Name", sample.Name);
        await data.UpdateAsync("Username", sample.Username);
        await data.UpdateAsync("Password", sample.Password);
        await data.UpdateAsync("Category", sample.Category);
    }

    public async Task<List<StoredPassword>> GetPasswords()
    {
        await SetupFirestore();
        var data = await db
                        .Collection("StoredPassword")
                        .GetSnapshotAsync();
        var passwordsData = data.Documents
            .Select(doc =>
            {
                var passwordData = doc.ConvertTo<StoredPassword>();
                passwordData.DocId = doc.Id; // FirebaseId hinzufügen
                return passwordData;
            })
            .ToList();
        return passwordsData;
    }
}
