using LibrarySystem.API.Models.Entities;
using QubitTech.Repositories.Repositories;

namespace LibrarySystem.API.Repositories.Abstracts;

public interface IMemberRepository : IAsyncRepository<Member, Guid>, ISyncRepository<Member, Guid>
{
    
}