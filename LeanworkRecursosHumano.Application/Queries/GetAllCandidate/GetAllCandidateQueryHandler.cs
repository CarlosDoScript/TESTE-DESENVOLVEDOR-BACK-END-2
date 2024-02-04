using LeanworkRecursosHumano.Application.ViewModels;
using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Queries.GetAllCandidate
{
    public class GetAllCandidateQueryHandler : IRequestHandler<GetAllCandidateQuery, List<CandidateViewModel>>
    {
        private readonly ICandidateRepository _candidateRepository;

        public GetAllCandidateQueryHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<List<CandidateViewModel>> Handle(GetAllCandidateQuery request, CancellationToken cancellationToken)
        {
            var candidates = await _candidateRepository.GetAllAsync();

            var candidateViewModel = candidates.Select(c => new CandidateViewModel(
                c.Id,
                c.Name,
                c.Email,
                c.CellPhone,
                c.Active,
                c.IdJobOpening
                )).ToList();

            return candidateViewModel;
        }
    }
}
