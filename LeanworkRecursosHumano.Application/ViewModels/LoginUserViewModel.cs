using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.ViewModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string userName, string token)
        {
            UserName = userName;
            Token = token;
        }

        public string UserName { get; private set; }
        public string Token { get; private set; }
    }
}
