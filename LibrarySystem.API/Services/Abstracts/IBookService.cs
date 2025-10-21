using LibrarySystem.API.Models.Dtos.Books;

namespace LibrarySystem.API.Services.Abstracts;

public interface IBookService
{
    Task AddAsync(BookAddRequestDto dto , CancellationToken cancellation=default);
    Task UpdateAsync(BookUpdateRequestDto dto , CancellationToken cancellation=default);
    List<BookResponseDto> GetAllAsync(CancellationToken cancellation= default);
    BookResponseDto GetById(Guid id, CancellationToken cancellation = default);
    Task DeleteAsync(Guid id,CancellationToken cancellation= default);


}