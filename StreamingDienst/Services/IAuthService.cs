using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace StreamingDienst.Services
{
    interface IAuthService
    {
        Task<bool> LoginAsync(string email, SecureString password);
    }
}
