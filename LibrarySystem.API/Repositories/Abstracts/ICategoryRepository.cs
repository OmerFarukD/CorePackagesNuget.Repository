using System.Security.Cryptography.X509Certificates;
using LibrarySystem.API.Models.Entities;
using QubitTech.Repositories.Repositories;

namespace LibrarySystem.API.Repositories.Abstracts;

public interface ICategoryRepository : IAsyncRepository<Category,int>,ISyncRepository<Category,int> 
{
    
}