using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.CreateCandidate
{
    public class CreateCandidateCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
    }
}
