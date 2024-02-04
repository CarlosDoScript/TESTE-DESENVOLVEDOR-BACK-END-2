using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.CreateJobOpening
{
    public class CreateJobOpeningCommandHandler : IRequestHandler<CreateJobOpeningCommand, int>
    {
        private readonly IJobOpeningRepository _jobOpeningRepository;

        public CreateJobOpeningCommandHandler( IJobOpeningRepository jobOpeningRepository)
        {
            _jobOpeningRepository = jobOpeningRepository;
        }

        public async Task<int> Handle(CreateJobOpeningCommand request, CancellationToken cancellationToken)
        {
            var id = await _jobOpeningRepository.PostAsync(request.Titile,request.Description,request.ScreeningPeriod);

            return id;
        }
    }
}
