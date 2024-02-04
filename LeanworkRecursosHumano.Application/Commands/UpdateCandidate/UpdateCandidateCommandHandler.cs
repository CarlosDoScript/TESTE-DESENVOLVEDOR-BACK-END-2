using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.UpdateCandidate
{
    public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand, Unit>
    {
        private readonly ICandidateRepository _candidateRepository;

        public UpdateCandidateCommandHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<Unit> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            await _candidateRepository.UpdateAsync(
                request.Id,
                request.Name,
                request.Email,
                request.CellPhone
                );

            return Unit.Value;
        }
    }
}
