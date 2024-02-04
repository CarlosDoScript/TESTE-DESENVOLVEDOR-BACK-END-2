using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.CreateTechnologyJobOpening
{
    public class CreateTechnologyJobOpeningCommand : IRequest<int>
    {
        public int IdJobOpening { get; set; }
        public int IdTechnology { get; set; }
    }
}
