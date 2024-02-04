using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.UpdateTechnologyJobOpening
{
    public class UpdateTechnologyJobOpeningCommandHandler : IRequestHandler<UpdateTechnologyJobOpeningCommand, Unit>
    {
        private readonly ITechnologyJobOpeningRepository _technologyJobOpening;

        public UpdateTechnologyJobOpeningCommandHandler(ITechnologyJobOpeningRepository technologyJobOpeningRepository)
        {
            _technologyJobOpening = technologyJobOpeningRepository;
        }
        public async Task<Unit> Handle(UpdateTechnologyJobOpeningCommand request, CancellationToken cancellationToken)
        {
            await _technologyJobOpening.UpdateAsync(request.IdJobOpening,request.IdTechnology);

            return Unit.Value;
        }
    }
}
