using LeanworkRecursosHumano.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Queries.GetTechnologyJobOpeningById
{
    public class GetTechnologyJobOpeningByIdQuery : IRequest<List<TechnologyJobOpeningViewModel>>
    {
        public GetTechnologyJobOpeningByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
