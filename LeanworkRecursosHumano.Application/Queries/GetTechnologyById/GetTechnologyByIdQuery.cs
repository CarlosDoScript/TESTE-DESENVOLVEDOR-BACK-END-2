using LeanworkRecursosHumano.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Queries.GetTechnologyById
{
    public class GetTechnologyByIdQuery : IRequest<TechnologyViewModel>
    {
        public GetTechnologyByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
