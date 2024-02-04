using LeanworkRecursosHumano.Application.ViewModels;
using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Queries.GetAllTechnology
{
    public class GetAllTechnologyQueryHandler : IRequestHandler<GetAllTechnologyQuery, List<TechnologyViewModel>>
    {
        private readonly ITechnologyRepository _technologyRepository;

        public GetAllTechnologyQueryHandler(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }
        public async Task<List<TechnologyViewModel>> Handle(GetAllTechnologyQuery request, CancellationToken cancellationToken)
        {
            var technologys = await _technologyRepository.GetAllAsync();

            if (technologys == null)
            {
                return new List<TechnologyViewModel>();
            }

            var technologysViewModel = technologys
                .Select(t => new TechnologyViewModel(
                    t.Id,
                    t.Name,
                    t.Description,
                    t.Weight,
                    t.IdCompany
                    )).ToList();


            return technologysViewModel;
        }
    }
}
