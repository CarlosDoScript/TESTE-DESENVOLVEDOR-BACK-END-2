using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.DeleteJobOpening
{
    public class DeleteJobOpeningCommand : IRequest<Unit>
    {
        public DeleteJobOpeningCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
