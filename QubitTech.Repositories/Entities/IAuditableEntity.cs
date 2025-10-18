namespace QubitTech.Repositories.Entities;

public interface IAuditableEntity
{
    string? CreatedBy { get; set; }
    

    DateTime CreatedTime { get; set; }
    

    string? UpdatedBy { get; set; }
    
 
    DateTime? UpdatedTime { get; set; }
}