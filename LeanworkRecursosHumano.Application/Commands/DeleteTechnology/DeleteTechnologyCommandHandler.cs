using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, Unit>
    {
        private readonly ITechnologyRepository _technologyRepository;

        public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task<Unit> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
        {
            await _technologyRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
