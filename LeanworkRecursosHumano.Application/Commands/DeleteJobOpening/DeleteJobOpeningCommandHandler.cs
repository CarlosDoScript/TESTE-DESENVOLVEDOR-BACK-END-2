using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.DeleteJobOpening
{
    public class DeleteJobOpeningCommandHandler : IRequestHandler<DeleteJobOpeningCommand, Unit>
    {
        private readonly IJobOpeningRepository _jobOpeningRepository;

        public DeleteJobOpeningCommandHandler(IJobOpeningRepository jobOpeningRepository)
        {
            _jobOpeningRepository = jobOpeningRepository;
        }

        public async Task<Unit> Handle(DeleteJobOpeningCommand request, CancellationToken cancellationToken)
        {
            await _jobOpeningRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
