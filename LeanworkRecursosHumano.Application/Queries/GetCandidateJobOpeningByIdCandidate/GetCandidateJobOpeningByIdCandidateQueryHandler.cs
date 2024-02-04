using LeanworkRecursosHumano.Application.ViewModels;
using LeanworkRecursosHumano.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Queries.GetAllByIdCandidate
{
    public class GetCandidateJobOpeningByIdCandidateQueryHandler : IRequestHandler<GetCandidateJobOpeningByIdCandidateQuery, InterviewCandidateViewModel>
    {
        private readonly IInterviewRepository _IInterviewRepository;

        public GetCandidateJobOpeningByIdCandidateQueryHandler(IInterviewRepository interviewRepository)
        {
            _IInterviewRepository = interviewRepository;
        }

        public async Task<InterviewCandidateViewModel> Handle(GetCandidateJobOpeningByIdCandidateQuery request, CancellationToken cancellationToken)
        {
            var InterviewCandidates= await _IInterviewRepository.GetByIdCandidateAsync(request.Id);

            if (InterviewCandidates == null)
            {
                return null;
            }

            var interviewCandidatesViewModel = new InterviewCandidateViewModel(
                InterviewCandidates.NameCandidate,
                InterviewCandidates.TitleJobOpening,
                InterviewCandidates.IdCandidate,
                InterviewCandidates.IdJobOpening
                );

            return interviewCandidatesViewModel;
        }
    }
}
