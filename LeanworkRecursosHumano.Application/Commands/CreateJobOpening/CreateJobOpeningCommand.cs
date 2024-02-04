using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.CreateJobOpening
{
    public class CreateJobOpeningCommand : IRequest<int>
    {
        public string Titile { get; set; }
        public string Description { get; set; }
        public DateTime ScreeningPeriod { get; set; }
    }
}
