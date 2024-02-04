using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.CreateTechnology
{
    public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, int>
    {
        private readonly ITechnologyRepository _technologyRepository;

        public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task<int> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
        {
            var id = await _technologyRepository.PostAsync(request.Name,
                request.Description,
                request.Weight
                );

            return id;
        }
    }
}
