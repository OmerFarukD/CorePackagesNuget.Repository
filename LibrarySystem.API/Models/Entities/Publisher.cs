using QubitTech.Repositories.Entities;

namespace LibrarySystem.API.Models.Entities;

public class Publisher : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public int FoundedYear { get; set; }
    
    public List<Book> Books { get; set; } = new();
}