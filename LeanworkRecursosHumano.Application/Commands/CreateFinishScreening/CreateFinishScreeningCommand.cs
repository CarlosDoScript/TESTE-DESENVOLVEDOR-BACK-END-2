using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.CreateFinishScreening
{
    public class CreateFinishScreeningCommand : IRequest<Unit>
    {
        public int MyProperty { get; set; }
    }
}
