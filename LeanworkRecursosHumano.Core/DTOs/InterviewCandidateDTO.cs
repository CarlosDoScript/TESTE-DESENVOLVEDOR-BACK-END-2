using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Core.DTOs
{
    public class InterviewCandidateDTO
    {
        public InterviewCandidateDTO(string nameCandidate, string titleJobOpening, string descriptionJobOpening, int idCandidate, int idJobOpening)
        {
            NameCandidate = nameCandidate;
            TitleJobOpening = titleJobOpening;
            DescriptionJobOpening = descriptionJobOpening;
            IdCandidate = idCandidate;
            IdJobOpening = idJobOpening;
        }

        public string NameCandidate { get; private set; }
        public string TitleJobOpening { get; private set; }
        public string DescriptionJobOpening { get; private set; }
        public int IdCandidate { get; private set; }
        public int IdJobOpening { get; private set; }
    }
}
