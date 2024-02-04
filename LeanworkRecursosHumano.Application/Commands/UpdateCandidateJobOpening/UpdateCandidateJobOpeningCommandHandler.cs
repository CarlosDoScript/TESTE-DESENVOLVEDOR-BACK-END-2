using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.UpdateCandidateJobOpening
{
    public class UpdateCandidateJobOpeningCommandHandler : IRequestHandler<UpdateCandidateJobOpeningCommand, Unit>
    {
        private readonly IInterviewRepository _iinterviewRepository;
        public UpdateCandidateJobOpeningCommandHandler(IInterviewRepository interviewRepository)
        {
            _iinterviewRepository = interviewRepository;
        }

        public async Task<Unit> Handle(UpdateCandidateJobOpeningCommand request, CancellationToken cancellationToken)
        {
            await _iinterviewRepository.UpdateAsync(request.IdCandidate,request.IdJobOpening);

            return Unit.Value;
        }
    }
}
