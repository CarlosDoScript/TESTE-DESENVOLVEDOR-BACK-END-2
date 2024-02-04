using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.DeleteTechnologyJobOpening
{
    public class DeleteTechnologyJobOpeningCommandHandler : IRequestHandler<DeleteTechnologyJobOpeningCommand, Unit>
    {
        private readonly ITechnologyJobOpeningRepository _technologyJobOpeningRepository;
        public DeleteTechnologyJobOpeningCommandHandler(ITechnologyJobOpeningRepository technologyJobOpeningRepository)
        {
            _technologyJobOpeningRepository = technologyJobOpeningRepository;   
        }

        public async Task<Unit> Handle(DeleteTechnologyJobOpeningCommand request, CancellationToken cancellationToken)
        {
            await _technologyJobOpeningRepository.DeleteAsync(request.IdJobOpening);

            return Unit.Value;
        }
    }
}
