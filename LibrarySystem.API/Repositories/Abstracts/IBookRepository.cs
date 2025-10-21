using LibrarySystem.API.Models.Entities;
using QubitTech.Repositories.Repositories;

namespace LibrarySystem.API.Repositories.Abstracts;

public interface IBookRepository : IAsyncRepository<Book,Guid> , ISyncRepository<Book,Guid>
{
    
}