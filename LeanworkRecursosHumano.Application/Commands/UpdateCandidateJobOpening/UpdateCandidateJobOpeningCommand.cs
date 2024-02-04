using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.UpdateCandidateJobOpening
{
    public class UpdateCandidateJobOpeningCommand :IRequest<Unit>
    {
        public int IdCandidate {  get; set; }
        public int IdJobOpening { get; set; }
    }
}
