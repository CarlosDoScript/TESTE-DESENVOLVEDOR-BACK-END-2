using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.UpdateTechnologyCandidate
{
    public class UpdateTechnologyCandidateCommand : IRequest<Unit>
    {
        public int IdCandidate { get; set; }
        public int IdTechnology { get; set; }
    }
}
