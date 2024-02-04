using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.DeleteCandidate
{
    public class DeleteCandidateCommand : IRequest<Unit>
    {
        public DeleteCandidateCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
