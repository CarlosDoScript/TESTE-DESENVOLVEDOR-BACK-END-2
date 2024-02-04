using LeanworkRecursosHumano.Application.ViewModels;
using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Queries.GetInfoReportByCandidateByTechnology
{
    public class GetInfoReportByCandidateByTechnologyQueryHandler : IRequestHandler<GetInfoReportByCandidateByTechnologyQuery, List<InterviewInfoReportViewModel>>
    {
        private readonly IInterviewRepository _iinterviewRepository;

        public GetInfoReportByCandidateByTechnologyQueryHandler(IInterviewRepository interviewRepository)
        {
            _iinterviewRepository = interviewRepository;
        }

        public async Task<List<InterviewInfoReportViewModel>> Handle(GetInfoReportByCandidateByTechnologyQuery request, CancellationToken cancellationToken)
        {
            var infoReport = await _iinterviewRepository.GetInfoByReportAsync();

            var infoReportViewModel = infoReport.Select( ir =>
                new InterviewInfoReportViewModel(
                    ir.NameCandidate,
                    ir.TechnologyCandidate,
                    ir.TechnologyWeight
                    )).ToList();

            return infoReportViewModel;
        }
    }
}
