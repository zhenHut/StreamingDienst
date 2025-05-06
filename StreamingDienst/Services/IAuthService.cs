using System.Security;

namespace StreamingDienst.Services
{
    interface IAuthService
    {
        Task<bool> LoginAsync(string email, SecureString password);
    }
}
