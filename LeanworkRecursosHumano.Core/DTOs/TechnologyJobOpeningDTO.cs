using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Core.DTOs
{
    public class TechnologyJobOpeningDTO
    {
        public TechnologyJobOpeningDTO(string titleJobOpening, string descriptionJobOpening, string nameTechnology, string descriptionTechnology, int idJobOpening, int idTechnology)
        {
            TitleJobOpening = titleJobOpening;
            DescriptionJobOpening = descriptionJobOpening;
            NameTechnology = nameTechnology;
            DescriptionTechnology = descriptionTechnology;
            IdJobOpening = idJobOpening;
            IdTechnology = idTechnology;
        }

        public string TitleJobOpening { get; private set; }
        public string DescriptionJobOpening { get; private set; }
        public string NameTechnology { get; private set; }
        public string DescriptionTechnology { get; private set; }
        public int IdJobOpening { get; private set; }
        public int IdTechnology { get; private set; }
    }
}
