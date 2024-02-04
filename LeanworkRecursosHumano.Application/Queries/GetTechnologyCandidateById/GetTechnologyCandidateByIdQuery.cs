using LeanworkRecursosHumano.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Queries.GetTechnologyCandidateById
{
    public class GetTechnologyCandidateByIdQuery : IRequest<List<TechnologyCandidateViewModel>>
    {
        public GetTechnologyCandidateByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
