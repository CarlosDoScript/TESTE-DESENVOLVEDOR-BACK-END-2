using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.ViewModels
{
    public class InterviewCandidateViewModel
    {
        public InterviewCandidateViewModel(string nameCandidate, string titleJobOpening, int idCandidate, int idJobOpening)
        {
            NameCandidate = nameCandidate;
            TitleJobOpening = titleJobOpening;
            IdCandidate = idCandidate;
            IdJobOpening = idJobOpening;
        }

        public string NameCandidate { get; private set; }
        public string TitleJobOpening { get; private set; }
        public int IdCandidate { get; private set; }
        public int IdJobOpening { get; private set; }
    }
}
