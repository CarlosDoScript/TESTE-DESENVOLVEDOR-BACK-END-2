using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.ViewModels
{
    public class JobOpeningViewModel
    {
        public JobOpeningViewModel(int id, string title, string description, DateTime screeningPeriod)
        {
            Id = id;
            Title = title;
            Description = description;
            ScreeningPeriod = screeningPeriod;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime ScreeningPeriod { get; private set; }
        public bool Active { get; private set; }
    }
}
