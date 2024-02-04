using LeanworkRecursosHumano.Application.ViewModels;
using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Queries.GetAllCandidateTechnology
{
    public class GetAllTechnologyCandidateQueryHandler : IRequestHandler<GetAllTechnologyCandidateQuery, List<TechnologyCandidateViewModel>>
    {
        private readonly ITechnologyCandidateRepository _technologyCandidateRepository;

        public GetAllTechnologyCandidateQueryHandler(ITechnologyCandidateRepository technologyCandidateRepository)
        {
            _technologyCandidateRepository = technologyCandidateRepository;
        }
        public async Task<List<TechnologyCandidateViewModel>> Handle(GetAllTechnologyCandidateQuery request, CancellationToken cancellationToken)
        {
            var technologysCandidate = await _technologyCandidateRepository.GetAllAsync();

            var technologysCandidateViewModel = technologysCandidate.Select( tc =>
                new TechnologyCandidateViewModel(
                    tc.NameCandidate,
                    tc.NameTechnology,
                    tc.DescriptionTechnology,
                    tc.IdCandidate,
                    tc.IdTechnology
                    )).ToList();

            return technologysCandidateViewModel;
        }
    }
}
