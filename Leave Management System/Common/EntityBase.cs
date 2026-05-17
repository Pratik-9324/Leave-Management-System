namespace Leave_Management_System.Common;

public abstract class EntityBase
{
    public long Id { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted {get; set;} = false;
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    public DateTime? UpdatedAt {get; set;}
    public long? CreatedBy {get; set;}
    public long? UpdatedBy {get; set;}
}
