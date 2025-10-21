using LibrarySystem.API.Models.Entities;
using QubitTech.Repositories.Repositories;

namespace LibrarySystem.API.Repositories.Abstracts;

public interface ILoanRepository : IAsyncRepository<Loan, Guid>, ISyncRepository<Loan, Guid>
{
    
}