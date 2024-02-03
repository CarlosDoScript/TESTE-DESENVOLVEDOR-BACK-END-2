using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Core.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string userName);
    }
}
