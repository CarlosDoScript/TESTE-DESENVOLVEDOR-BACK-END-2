using LeanworkRecursosHumano.Application.ViewModels;
using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Queries.GetAllCandidateJobOpening
{
    public class GetAllCandidateJobOpeningQueryHandler : IRequestHandler<GetAllCandidateJobOpeningQuery, List<InterviewCandidateViewModel>>
    {
        private readonly IInterviewRepository _iinterviewRepository;

        public GetAllCandidateJobOpeningQueryHandler(IInterviewRepository interviewRepository)
        {
            _iinterviewRepository = interviewRepository;
        }

        public async Task<List<InterviewCandidateViewModel>> Handle(GetAllCandidateJobOpeningQuery request, CancellationToken cancellationToken)
        {
            var candidatesInterviews = await _iinterviewRepository.GetAllAsync();


            var candidatesInterviewsViewModel = candidatesInterviews.Select(ci =>
                new InterviewCandidateViewModel(
                    ci.NameCandidate,
                    ci.TitleJobOpening,
                    ci.IdCandidate,
                    ci.IdJobOpening
                    )).ToList();

            return candidatesInterviewsViewModel;
        }
    }
}
