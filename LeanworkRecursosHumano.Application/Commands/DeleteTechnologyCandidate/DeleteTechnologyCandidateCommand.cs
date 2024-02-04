using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.DeleteTechnologyCandidate
{
    public class DeleteTechnologyCandidateCommand : IRequest<Unit>
    {
        public DeleteTechnologyCandidateCommand(int idCandidate)
        {
            IdCandidate = idCandidate;
        }

        public int IdCandidate { get; private set; }
    }
}
