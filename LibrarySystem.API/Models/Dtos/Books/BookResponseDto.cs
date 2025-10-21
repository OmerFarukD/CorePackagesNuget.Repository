using LibrarySystem.API.Models.Enums;

namespace LibrarySystem.API.Models.Dtos.Books;

public sealed class BookResponseDto
{

    private string _status;
    
    public Guid Id { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string AuthorFullName { get; set; }
    public string PublisherName { get; set; }
    
    public BookStatus BookStatus { private get; set; }

    public string Status
    {
        get=>_status;
        set => ConvertTextByStatus(BookStatus);
    }



    private string ConvertTextByStatus(BookStatus status) => BookStatus switch
    {
        BookStatus.Available => "Mevcut",
        BookStatus.Unavailable => "Mevcut Değil",
        BookStatus.Damaged => "Hasarlı",
        BookStatus.Lost => "Kayıp"
    };


}