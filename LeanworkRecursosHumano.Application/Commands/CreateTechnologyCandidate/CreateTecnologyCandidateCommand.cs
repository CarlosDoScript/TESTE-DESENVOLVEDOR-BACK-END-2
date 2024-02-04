using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.CreateTechnologyCandidate
{
    public class CreateTecnologyCandidateCommand : IRequest<int>
    {
        public int IdCandidate { get; set; }
        public int IdTechnology { get; set; }
    }
}
