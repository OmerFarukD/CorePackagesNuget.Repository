namespace QubitTech.Repositories.Entities;

public abstract class Entity<TId> : IAuditableEntity,ISoftDeletable
{
    public TId Id { get; set; }

    public string? CreatedBy { get; set; }
    public DateTime CreatedTime { get; set; }
    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedTime { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public DateTime? DeletedTime { get; set; }
    public string? DeletedBy { get; set; }


    protected Entity()
    {
        Id = default;
        IsDeleted = false;
    }

    protected Entity(TId id)
    {
        Id = id;
        IsDeleted = false;
    }
    
}