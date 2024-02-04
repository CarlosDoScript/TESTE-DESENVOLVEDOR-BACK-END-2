using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.DeleteTechnologyJobOpening
{
    public class DeleteTechnologyJobOpeningCommand : IRequest<Unit>
    {
        public DeleteTechnologyJobOpeningCommand(int idJobOpening)
        {
            IdJobOpening = idJobOpening;
        }

        public int IdJobOpening { get; private set; }
    }
}
