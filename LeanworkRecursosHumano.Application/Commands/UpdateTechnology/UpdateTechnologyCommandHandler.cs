using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, Unit>
    {
        private readonly ITechnologyRepository _technologyRepository;

        public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task<Unit> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
        {
            await _technologyRepository.UpdateAsync(
                request.Id,
                request.Name,
                request.Description,
                request.Weight
                );

            return Unit.Value;
        }
    }
}
