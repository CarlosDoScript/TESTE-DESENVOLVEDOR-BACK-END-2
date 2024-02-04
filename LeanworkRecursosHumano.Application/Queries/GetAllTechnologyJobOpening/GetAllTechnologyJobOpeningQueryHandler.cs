using LeanworkRecursosHumano.Application.ViewModels;
using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Queries.GetAllTechnologyJobOpening
{
    public class GetAllTechnologyJobOpeningQueryHandler : IRequestHandler<GetAllTechnologyJobOpeningQuery, List<TechnologyJobOpeningViewModel>>
    {
        private readonly ITechnologyJobOpeningRepository _technologyJobOpeningRepository;

        public GetAllTechnologyJobOpeningQueryHandler(ITechnologyJobOpeningRepository tecnologyJobOpeningRepository)
        {
            _technologyJobOpeningRepository = tecnologyJobOpeningRepository;
        }

        public async Task<List<TechnologyJobOpeningViewModel>> Handle(GetAllTechnologyJobOpeningQuery request, CancellationToken cancellationToken)
        {
            var technologysJobOpenings = await _technologyJobOpeningRepository.GetAllAsync();

            var technologysJobOpeningsViewModel = technologysJobOpenings.Select( tj => 
                new TechnologyJobOpeningViewModel(
                    tj.TitleJobOpening,
                    tj.DescriptionJobOpening,
                    tj.NameTechnology,
                    tj.DescriptionTechnology,
                    tj.IdJobOpening,
                    tj.IdTechnology
                    )).ToList();

            return technologysJobOpeningsViewModel;
        }
    }
}
