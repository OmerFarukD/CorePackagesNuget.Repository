using LibrarySystem.API.Models.Enums;
using QubitTech.Repositories.Entities;

namespace LibrarySystem.API.Models.Entities;

public class Book : Entity<Guid>
{
    public string ISBN { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public BookStatus Status { get; set; }
    
    // Foreign Keys
    public Guid AuthorId { get; set; }
    public Guid PublisherId { get; set; }
    public int CategoryId { get; set; }
    
    // Navigation Properties
    public Author Author { get; set; } = null!;
    public Publisher Publisher { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public List<Loan> Loans { get; set; } = new();
}