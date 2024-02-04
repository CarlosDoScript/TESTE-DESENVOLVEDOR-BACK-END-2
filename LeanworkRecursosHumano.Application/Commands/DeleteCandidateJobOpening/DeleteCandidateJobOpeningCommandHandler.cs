using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.DeleteCandidateJobOpening
{
    public class DeleteCandidateJobOpeningCommandHandler : IRequestHandler<DeleteCandidateJobOpeningCommand, Unit>
    {
        private readonly IInterviewRepository _iinterviewRepository;

        public DeleteCandidateJobOpeningCommandHandler(IInterviewRepository interviewRepository)
        {
            _iinterviewRepository = interviewRepository;
        }

        public async Task<Unit> Handle(DeleteCandidateJobOpeningCommand request, CancellationToken cancellationToken)
        {
            await _iinterviewRepository.DeleteAsync(request.IdCandidate);

            return Unit.Value;
        }
    }
}
