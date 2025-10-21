using LibrarySystem.API.Models.Entities;
using QubitTech.Repositories.Repositories;

namespace LibrarySystem.API.Repositories.Abstracts;

public interface IAuthorRepository : IAsyncRepository<Author, Guid>, ISyncRepository<Author, Guid>
{
    
}