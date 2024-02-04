using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.UpdateTechnologyJobOpening
{
    public class UpdateTechnologyJobOpeningCommand : IRequest<Unit>
    {
        public int IdJobOpening { get; set; }
        public int IdTechnology { get; set; }
    }
}
