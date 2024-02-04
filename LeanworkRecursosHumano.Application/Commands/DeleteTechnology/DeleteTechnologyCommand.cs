using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<Unit>
    {
        public DeleteTechnologyCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
