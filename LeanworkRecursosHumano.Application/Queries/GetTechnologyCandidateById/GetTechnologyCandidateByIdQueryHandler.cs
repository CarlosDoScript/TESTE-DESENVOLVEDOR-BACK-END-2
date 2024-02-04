using LeanworkRecursosHumano.Application.ViewModels;
using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Queries.GetTechnologyCandidateById
{
    public class GetTechnologyCandidateByIdQueryHandler : IRequestHandler<GetTechnologyCandidateByIdQuery, List<TechnologyCandidateViewModel>>
    {
        private readonly ITechnologyCandidateRepository _technologyCandidate;

        public GetTechnologyCandidateByIdQueryHandler(ITechnologyCandidateRepository technologyCandidateRepository)
        {
            _technologyCandidate = technologyCandidateRepository;
        }
        public async Task<List<TechnologyCandidateViewModel>> Handle(GetTechnologyCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            var technologyCandidate = await _technologyCandidate.GetByIdCandidateAsync(request.Id);

            if (technologyCandidate == null)
            {
                return null;
            }

            var technologyCandidateViewModel = technologyCandidate.Select(tc =>
            new TechnologyCandidateViewModel(
                tc.NameCandidate,
                tc.NameTechnology,
                tc.DescriptionTechnology,
                tc.IdCandidate,
                tc.IdTechnology
                )).ToList();

            return technologyCandidateViewModel;
        }
    }
}
