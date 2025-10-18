namespace QubitTech.Repositories.Entities;

public interface ISoftDeletable
{

    bool IsDeleted { get; set; }
    

    DateTime? DeletedTime { get; set; }
    

    string? DeletedBy { get; set; }
}