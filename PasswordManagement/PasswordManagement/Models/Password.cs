using Google.Cloud.Firestore;
using SQLite;

namespace PasswordManagement.Models;

// [Table("stored_password")]
[FirestoreData]
public class StoredPassword
{
    [FirestoreProperty]
    public string Id { get; set; }

    [FirestoreProperty]
    public string Name { get; set; }

    [FirestoreProperty]
    public string Username { get; set; }

    [FirestoreProperty]
    public string Password { get; set; }

    [FirestoreProperty]
    public string Category { get; set; }

    [FirestoreProperty]
    public DateTime CreatedAt { get; set; }

}

public class DateTimeToTimestampConverter : IFirestoreConverter<DateTime>
{
    public object ToFirestore(DateTime value) => Timestamp.FromDateTime(value.ToUniversalTime());

    public DateTime FromFirestore(object value)
    {
        if (value is Timestamp timestamp)
        {
            return timestamp.ToDateTime();
        }
        throw new ArgumentException("Invalid value");
    }
}
