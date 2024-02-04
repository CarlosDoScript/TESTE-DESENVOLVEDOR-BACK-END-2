using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.CreateTechnology
{
    public class CreateTechnologyCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
    }
}
