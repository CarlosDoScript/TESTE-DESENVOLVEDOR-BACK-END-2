using LeanworkRecursosHumano.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.Queries.GetJobOpeningById
{
    public class GetJobOpeningByIdQuery : IRequest<JobOpeningViewModel>
    {
        public GetJobOpeningByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
