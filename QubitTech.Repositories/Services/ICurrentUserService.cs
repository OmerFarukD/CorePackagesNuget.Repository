namespace QubitTech.Repositories.Services;

public interface ICurrentUserService
{
    string? UserId { get; }

    string? Username { get; }
    
    bool IsAuthenticated { get; }
}