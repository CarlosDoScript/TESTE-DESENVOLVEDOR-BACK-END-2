using LeanworkRecursosHumano.Application.ViewModels;
using LeanworkRecursosHumano.Core.Repositories;
using LeanworkRecursosHumano.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IPersonRH _personRH;
        public LoginUserCommandHandler(IPersonRH personRH,IAuthService authService)
        {
            _personRH = personRH;
            _authService = authService;
        }
        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _personRH.GetPersonByNameLoginAndPasswordAsync(request.UserName, request.Password);

            if (user == null)
            {
                return null;
            }

            var token = _authService.GenerateJwtToken(user.Username);

            var loginViewModel = new LoginUserViewModel(user.Username,token);

            return new LoginUserViewModel(loginViewModel.UserName,loginViewModel.Token);
        }
    }
}
