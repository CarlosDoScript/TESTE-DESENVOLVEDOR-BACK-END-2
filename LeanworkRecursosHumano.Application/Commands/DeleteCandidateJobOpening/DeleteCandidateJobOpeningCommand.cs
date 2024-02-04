using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.DeleteCandidateJobOpening
{
    public class DeleteCandidateJobOpeningCommand : IRequest<Unit>
    {
        public DeleteCandidateJobOpeningCommand(int idCandidate)
        {
            IdCandidate = idCandidate;
        }

        public int IdCandidate { get; private set; }
    }
}
