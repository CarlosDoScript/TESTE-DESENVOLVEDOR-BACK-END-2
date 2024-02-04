using LeanworkRecursosHumano.Application.ViewModels;
using LeanworkRecursosHumano.Core.Entities;
using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Queries.GetJobOpeningById
{
    public class GetJobOpeningByIdQueryHandler : IRequestHandler<GetJobOpeningByIdQuery, JobOpeningViewModel>
    {
        private readonly IJobOpeningRepository _jobOpeningRepository;

        public GetJobOpeningByIdQueryHandler(IJobOpeningRepository jobOpeningRepository)
        {
            _jobOpeningRepository = jobOpeningRepository;
        }

        public async Task<JobOpeningViewModel> Handle(GetJobOpeningByIdQuery request, CancellationToken cancellationToken)
        {
            var jobOpening = await _jobOpeningRepository.GetByIdAsync(request.Id);

            var jobOpeningsViewModel = new JobOpeningViewModel(
                jobOpening.Id,
                jobOpening.Title,
                jobOpening.Description,
                jobOpening.ScreeningPeriod
                );

            return jobOpeningsViewModel;
        }
    }
}
