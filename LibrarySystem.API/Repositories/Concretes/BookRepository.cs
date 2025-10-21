using LibrarySystem.API.Models.Entities;
using LibrarySystem.API.Repositories.Abstracts;
using LibrarySystem.API.Repositories.Contexts;
using QubitTech.Repositories.Repositories;

namespace LibrarySystem.API.Repositories.Concretes;

public class BookRepository : EfRepositoryBase<Book, Guid, LibraryDbContext>, IBookRepository
{
    public BookRepository(LibraryDbContext context, bool autoSaveChanges = true) : base(context, autoSaveChanges)
    {
    }
}