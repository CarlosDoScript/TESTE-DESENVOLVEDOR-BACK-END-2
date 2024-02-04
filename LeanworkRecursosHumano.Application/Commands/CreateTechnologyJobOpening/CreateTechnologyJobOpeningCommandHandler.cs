using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.CreateTechnologyJobOpening
{
    public class CreateTechnologyJobOpeningCommandHandler : IRequestHandler<CreateTechnologyJobOpeningCommand, int>
    {
        private readonly ITechnologyJobOpeningRepository _technologyJonOpening;

        public CreateTechnologyJobOpeningCommandHandler(ITechnologyJobOpeningRepository technologyJobOpeningRepository)
        {
            _technologyJonOpening = technologyJobOpeningRepository;
        }
        public async Task<int> Handle(CreateTechnologyJobOpeningCommand request, CancellationToken cancellationToken)
        {
            var id = await _technologyJonOpening.PostAsync(request.IdJobOpening, request.IdTechnology);

            return id;
        }
    }
}
