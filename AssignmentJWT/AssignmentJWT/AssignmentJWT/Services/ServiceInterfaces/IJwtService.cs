using AssignmentJWT.Models.RequestViewModels;

namespace AssignmentJWT.Services.ServiceInterfaces
{
    public interface IJwtService
    {
        Task<string> GenerateToken(User user);
    }
}
