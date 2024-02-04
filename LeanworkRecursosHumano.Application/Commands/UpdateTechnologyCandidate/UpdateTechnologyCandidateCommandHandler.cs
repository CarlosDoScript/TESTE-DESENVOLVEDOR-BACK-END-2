using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.UpdateTechnologyCandidate
{
    public class UpdateTechnologyCandidateCommandHandler : IRequestHandler<UpdateTechnologyCandidateCommand, Unit>
    {
        private readonly ITechnologyCandidateRepository _technologyCandidateRepository;

        public UpdateTechnologyCandidateCommandHandler(ITechnologyCandidateRepository technologyCandidateRepository)
        {
            _technologyCandidateRepository = technologyCandidateRepository;
        }

        public async Task<Unit> Handle(UpdateTechnologyCandidateCommand request, CancellationToken cancellationToken)
        {
            await _technologyCandidateRepository.UpdateAsync(request.IdCandidate,request.IdTechnology);

            return Unit.Value;
        }
    }
}
