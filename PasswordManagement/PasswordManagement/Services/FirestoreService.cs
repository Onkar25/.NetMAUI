using System;
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
    public async Task InsertSampleModel(StoredPassword sample)
    {
        await SetupFirestore();
        await db.Collection("StoredPassword").AddAsync(sample);
    }
    public async Task<List<StoredPassword>> GetSampleModels()
    {
        await SetupFirestore();
        var data = await db
                        .Collection("StoredPassword")
                        .GetSnapshotAsync();
        var sampleModels = data.Documents
            .Select(doc =>
            {
                var sampleModel = doc.ConvertTo<StoredPassword>();
                // sampleModel.Id = doc.Id; // FirebaseId hinzufügen
                return sampleModel;
            })
            .ToList();
        return sampleModels;
    }
}
