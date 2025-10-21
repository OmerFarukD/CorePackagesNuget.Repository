using LibrarySystem.API.Models.Entities;
using LibrarySystem.API.Repositories.Abstracts;
using LibrarySystem.API.Repositories.Contexts;
using QubitTech.Repositories.Repositories;

namespace LibrarySystem.API.Repositories.Concretes;

public class LoanRepository : EfRepositoryBase<Loan, Guid, LibraryDbContext>, ILoanRepository
{
    public LoanRepository(LibraryDbContext context, bool autoSaveChanges = true) : base(context, autoSaveChanges)
    {
    }
}