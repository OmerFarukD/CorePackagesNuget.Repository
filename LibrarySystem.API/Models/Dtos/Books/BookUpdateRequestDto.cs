using LibrarySystem.API.Models.Enums;

namespace LibrarySystem.API.Models.Dtos.Books;

public sealed class BookUpdateRequestDto
{
    public Guid Id { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public BookStatus Status { get; set; }
    
    public Guid AuthorId { get; set; }
    public Guid PublisherId { get; set; }
    public int CategoryId { get; set; }
}