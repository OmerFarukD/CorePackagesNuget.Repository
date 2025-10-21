using LibrarySystem.API.Models.Enums;
using QubitTech.Repositories.Entities;

namespace LibrarySystem.API.Models.Entities;

public class Loan : Entity<Guid>
{
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public LoanStatus Status { get; set; }
    public decimal? LateFee { get; set; }
    public string? Notes { get; set; }
    
    // Navigation Properties
    public Book Book { get; set; } = null!;
    public Member Member { get; set; } = null!;
    
    public bool IsOverdue => Status == LoanStatus.Active && DateTime.UtcNow > DueDate;
    public int DaysOverdue => IsOverdue ? (DateTime.UtcNow - DueDate).Days : 0;
}