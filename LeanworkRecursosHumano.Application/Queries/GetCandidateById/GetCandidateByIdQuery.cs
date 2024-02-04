using LeanworkRecursosHumano.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Queries.GetCandidateById
{
    public class GetCandidateByIdQuery : IRequest<CandidateViewModel>
    {
        public GetCandidateByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
