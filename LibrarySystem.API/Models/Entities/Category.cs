using QubitTech.Repositories.Entities;

namespace LibrarySystem.API.Models.Entities;

public class Category : Entity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public List<Book> Books { get; set; } = new();
}