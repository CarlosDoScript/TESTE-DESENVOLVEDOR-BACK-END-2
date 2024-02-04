using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.CreateInterview
{
    public class CreateInterviewCommand : IRequest<int>
    {
        public int IdCandidate { get; set; }
        public int IdJobOpening { get; set; }
    }
}
