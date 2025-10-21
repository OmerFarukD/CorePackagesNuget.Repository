using LibrarySystem.API.Models.Enums;
using QubitTech.Repositories.Entities;

namespace LibrarySystem.API.Models.Entities;

public class Member : Entity<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime JoinDate { get; set; }
    public MembershipType MembershipType { get; set; }
    public MemberStatus Status { get; set; }
    
    public List<Loan> Loans { get; set; } = new();
    
    public string FullName => $"{FirstName} {LastName}";
    public bool CanBorrow => Status == MemberStatus.Active && !IsDeleted;
}