using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Application.Commands.CreateInterview
{
    public class CreateInterviewCommandHandler : IRequestHandler<CreateInterviewCommand, int>
    {
        public async Task<int> Handle(CreateInterviewCommand request, CancellationToken cancellationToken)
        {
            return 1;
        }
    }
}
