using LeanworkRecursosHumano.Application.ViewModels;
using LeanworkRecursosHumano.Core.Entities;
using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Queries.GetAllJobOpening
{
    public class GetAllJobOpeningQueryHandler : IRequestHandler<GetAllJobOpeningQuery, List<JobOpeningViewModel>>
    {
        private readonly IJobOpeningRepository _jobOpeningRepository;

        public GetAllJobOpeningQueryHandler(IJobOpeningRepository jobOpeningRepository)
        {
            _jobOpeningRepository = jobOpeningRepository;
        }

        public async Task<List<JobOpeningViewModel>> Handle(GetAllJobOpeningQuery request, CancellationToken cancellationToken)
        {
            var jobOpenings = await _jobOpeningRepository.GetAllAsync();

            if (jobOpenings == null)
            {
                return new List<JobOpeningViewModel>();
            }

            var jobOpeningsViewModel = jobOpenings.Select(j => new JobOpeningViewModel(
                j.Id,
                j.Title,
                j.Description,
                j.ScreeningPeriod
                )).ToList();

            return jobOpeningsViewModel;
        }
    }
}
