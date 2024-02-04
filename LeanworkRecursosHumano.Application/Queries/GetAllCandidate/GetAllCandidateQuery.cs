using LeanworkRecursosHumano.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Queries.GetAllCandidate
{
    public class GetAllCandidateQuery : IRequest<List<CandidateViewModel>>
    {
    }
}
