using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Commands.UpdateJobOpening
{
    public class UpdateJobOpeningCommand : IRequest<Unit>
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ScreenPeriod { get; set; }
    }
}
