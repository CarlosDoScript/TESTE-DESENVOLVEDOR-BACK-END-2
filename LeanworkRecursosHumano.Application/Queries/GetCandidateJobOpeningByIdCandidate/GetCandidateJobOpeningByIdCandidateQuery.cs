using LeanworkRecursosHumano.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Queries.GetAllByIdCandidate
{
    public class GetCandidateJobOpeningByIdCandidateQuery : IRequest<InterviewCandidateViewModel>
    {
        public GetCandidateJobOpeningByIdCandidateQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
