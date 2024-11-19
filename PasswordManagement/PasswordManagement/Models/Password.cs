using Google.Cloud.Firestore;
namespace PasswordManagement.Models;
[FirestoreData]
public class StoredPassword
{
    [FirestoreProperty]
    public string DocId { get; set; }

    [FirestoreProperty]
    public int Id { get; set; }
    
    [FirestoreProperty]
    public required string Name { get; set; }

    [FirestoreProperty]
    public required string Username { get; set; }

    [FirestoreProperty]
    public required string Password { get; set; }

    [FirestoreProperty]
    public required string Category { get; set; }

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
