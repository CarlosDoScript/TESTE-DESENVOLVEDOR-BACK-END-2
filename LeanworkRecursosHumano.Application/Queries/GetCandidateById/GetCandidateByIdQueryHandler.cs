using LeanworkRecursosHumano.Application.ViewModels;
using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Queries.GetCandidateById
{
    public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, CandidateViewModel>
    {
        private readonly ICandidateRepository _candidateRepository;

        public GetCandidateByIdQueryHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<CandidateViewModel> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _candidateRepository.GetByIdAsync(request.Id);

            if (candidate == null)
            {
                return null;
            }

            var candidateViewModel = new CandidateViewModel(
                candidate.Id,
                candidate.Name,
                candidate.Email,
                candidate.CellPhone,
                candidate.Active,
                candidate.IdJobOpening
                );

            return candidateViewModel;
        }
    }
}
