using QubitTech.Repositories.Entities;

namespace LibrarySystem.API.Models.Entities;

public class Author : Entity<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Biography { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Country { get; set; } = string.Empty;
    
    public List<Book> Books { get; set; } = new();
    
    public string FullName => $"{FirstName} {LastName}";
}