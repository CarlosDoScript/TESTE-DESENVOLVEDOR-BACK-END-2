using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Core.Entities
{
    public class Technology
    {
        public Technology(){}

        public Technology(int id, string name, string description, int wight, bool active, int idCompany)
        {
            Id = id;
            Name = name;
            Description = description;
            Weight = wight;
            Active = active;
            IdCompany = idCompany;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Weight { get; private set; }
        public bool Active { get; private set; }
        public int IdCompany { get; private set; }
    }
}
