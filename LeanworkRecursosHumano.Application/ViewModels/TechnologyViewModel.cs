using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Application.ViewModels
{
    public class TechnologyViewModel
    {
        public TechnologyViewModel(int id, string name, string description, int weight, int idCompany)
        {
            Id = id;
            Name = name;
            Description = description;
            Weight = weight;
            IdCompany = idCompany;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Weight { get; private set; }
        public int IdCompany { get; private set; }
    }
}
