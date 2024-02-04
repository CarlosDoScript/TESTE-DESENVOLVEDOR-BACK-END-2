using LeanworkRecursosHumano.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Queries.GetAllTechnology
{
    public class GetAllTechnologyQuery : IRequest<List<TechnologyViewModel>>
    {
    }
}
