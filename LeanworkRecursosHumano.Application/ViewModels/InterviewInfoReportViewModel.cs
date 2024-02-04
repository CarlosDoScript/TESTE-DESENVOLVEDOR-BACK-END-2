using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.ViewModels
{
    public class InterviewInfoReportViewModel
    {
        public InterviewInfoReportViewModel(string nameCandidate, string technologyCandidate, int technologyWeight)
        {
            NameCandidate = nameCandidate;
            TechnologyCandidate = technologyCandidate;
            TechnologyWeight = technologyWeight;
        }

        public string NameCandidate { get; private set; }
        public string TechnologyCandidate { get; private set; }
        public int TechnologyWeight { get; private set; }
    }
}
