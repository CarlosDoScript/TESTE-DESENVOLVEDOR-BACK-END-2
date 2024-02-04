using LeanworkRecursosHumano.Application.ViewModels;
using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Queries.GetTechnologyById
{
    public class GetTechnologyByIdQueryHandler : IRequestHandler<GetTechnologyByIdQuery,TechnologyViewModel>
    {
        private readonly ITechnologyRepository _technologyRepository;

        public GetTechnologyByIdQueryHandler(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task<TechnologyViewModel> Handle(GetTechnologyByIdQuery request, CancellationToken cancellationToken)
        {
            var techonology = await _technologyRepository.GetByIdAsync(request.Id);

            var technologyViewModel = new TechnologyViewModel(
                techonology.Id,
                techonology.Name,
                techonology.Description,
                techonology.Weight,
                techonology.IdCompany
                );

            return technologyViewModel;
        }
    }
}
