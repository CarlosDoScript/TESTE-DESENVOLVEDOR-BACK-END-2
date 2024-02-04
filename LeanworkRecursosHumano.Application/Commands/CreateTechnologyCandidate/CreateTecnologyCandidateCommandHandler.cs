using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.CreateTechnologyCandidate
{
    public class CreateTecnologyCandidateCommandHandler : IRequestHandler<CreateTecnologyCandidateCommand, int>
    {
        private readonly ITechnologyCandidateRepository _technologyCandidateRepository;

        public CreateTecnologyCandidateCommandHandler(ITechnologyCandidateRepository technologyCandidateRepository)
        {
            _technologyCandidateRepository = technologyCandidateRepository;
        }

        public async Task<int> Handle(CreateTecnologyCandidateCommand request, CancellationToken cancellationToken)
        {
            var id = await _technologyCandidateRepository.PostAsync(request.IdCandidate,request.IdTechnology);

            return id;
        }
    }
}
