using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.CreateInterview
{
    public class CreateInterviewCommandHandler : IRequestHandler<CreateInterviewCommand, int>
    {
        private readonly IInterviewRepository _IInterviewRepository;

        public CreateInterviewCommandHandler(IInterviewRepository interviewRepository)
        {
            _IInterviewRepository = interviewRepository;
        }

        public async Task<int> Handle(CreateInterviewCommand request, CancellationToken cancellationToken)
        {
            var idCandidate = await _IInterviewRepository.PostAsync(request.IdCandidate,request.IdJobOpening);

            return idCandidate;
        }
    }
}
