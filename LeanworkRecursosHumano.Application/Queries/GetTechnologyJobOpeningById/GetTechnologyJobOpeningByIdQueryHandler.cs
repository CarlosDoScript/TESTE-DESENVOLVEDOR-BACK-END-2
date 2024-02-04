using LeanworkRecursosHumano.Application.ViewModels;
using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Queries.GetTechnologyJobOpeningById
{
    public class GetTechnologyJobOpeningByIdQueryHandler : IRequestHandler<GetTechnologyJobOpeningByIdQuery, List<TechnologyJobOpeningViewModel>>
    {
        private readonly ITechnologyJobOpeningRepository _technologyJobOpeningRepository;
        public GetTechnologyJobOpeningByIdQueryHandler(ITechnologyJobOpeningRepository technologyJobOpeningRepository)
        {
            _technologyJobOpeningRepository = technologyJobOpeningRepository;
        }

        public async Task<List<TechnologyJobOpeningViewModel>> Handle(GetTechnologyJobOpeningByIdQuery request, CancellationToken cancellationToken)
        {
            var technologysJobOpenings = await _technologyJobOpeningRepository.GetByIdJobOpeningAsync(request.Id);

            var technologysJobOpeningsViewModel = technologysJobOpenings.Select(tj =>
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
