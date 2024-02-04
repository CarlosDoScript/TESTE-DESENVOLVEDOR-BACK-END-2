using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.DeleteCandidate
{
    public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand, Unit>
    {
        private readonly ICandidateRepository _candidateRepository;

        public DeleteCandidateCommandHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<Unit> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            await _candidateRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
