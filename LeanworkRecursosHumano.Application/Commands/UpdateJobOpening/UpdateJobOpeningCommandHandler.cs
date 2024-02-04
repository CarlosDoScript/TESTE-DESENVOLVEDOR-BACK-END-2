using LeanworkRecursosHumano.Core.Repositories;
using LeanworkRecursosHumano.Infrastructure.Persistence.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.UpdateJobOpening
{
    public class UpdateJobOpeningCommandHandler : IRequestHandler<UpdateJobOpeningCommand, Unit>
    {
        private readonly IJobOpeningRepository _jobOpeningRepository;

        public UpdateJobOpeningCommandHandler(IJobOpeningRepository jobOpeningRepository)
        {
            _jobOpeningRepository = jobOpeningRepository;

        }

        public async Task<Unit> Handle(UpdateJobOpeningCommand request, CancellationToken cancellationToken)
        {
            await _jobOpeningRepository.UpdateAsync(
               request.Id,
               request.Title,
               request.Description,
               request.ScreenPeriod
               );

            return Unit.Value;
        }
    }
}
