using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.DeleteTechnologyCandidate
{
    public class DeleteTechnologyCandidateCommandHandler : IRequestHandler<DeleteTechnologyCandidateCommand, Unit>
    {
        private readonly ITechnologyCandidateRepository _technologyCandidateRepository;

        public DeleteTechnologyCandidateCommandHandler(ITechnologyCandidateRepository technologyCandidateRepository)
        {
            _technologyCandidateRepository = technologyCandidateRepository;
        }

        public async Task<Unit> Handle(DeleteTechnologyCandidateCommand request, CancellationToken cancellationToken)
        {
            await _technologyCandidateRepository.DeleteAsync(request.IdCandidate);
            
            return Unit.Value;
        }
    }
}
