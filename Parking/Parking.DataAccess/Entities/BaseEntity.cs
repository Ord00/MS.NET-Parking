namespace Parking.DataAccess.Entities;

public class BaseEntity
{
    public int Id { get; set; } //ключ в бд

    public Guid ExternalId { get; set; } // unique index
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
}