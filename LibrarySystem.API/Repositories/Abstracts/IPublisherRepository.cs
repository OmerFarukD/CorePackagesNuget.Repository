using LibrarySystem.API.Models.Entities;
using QubitTech.Repositories.Repositories;

namespace LibrarySystem.API.Repositories.Abstracts;

public interface IPublisherRepository : IAsyncRepository<Publisher, Guid>, ISyncRepository<Publisher, Guid>
{
    
}