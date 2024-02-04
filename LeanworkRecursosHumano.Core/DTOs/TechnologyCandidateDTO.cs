using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Core.DTOs
{
    public class TechnologyCandidateDTO
    {
        public TechnologyCandidateDTO(string nameCandidate, string nameTechnology, string descriptionTechnology, int idCandidate, int idTechnology)
        {
            NameCandidate = nameCandidate;
            NameTechnology = nameTechnology;
            DescriptionTechnology = descriptionTechnology;
            IdCandidate = idCandidate;
            IdTechnology = idTechnology;
        }

        public string NameCandidate { get; private set; }
        public string NameTechnology { get; private set; }
        public string DescriptionTechnology { get; private set; }
        public int IdCandidate { get; private set; }
        public int IdTechnology { get; private set; }
    }
}
