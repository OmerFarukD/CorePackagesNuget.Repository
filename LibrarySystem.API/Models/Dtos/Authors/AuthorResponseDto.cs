namespace LibrarySystem.API.Models.Dtos.Authors;

public sealed class AuthorResponseDto
{
    public string FullName { get; init; }
    public DateTime DateOfBirth { get; set; }
    public string Country { get; set; }
    
}