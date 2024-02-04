using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Core.Entities
{
    public class PersonRH
    {
        public PersonRH(){}

        public PersonRH(int Id, string Username, int Password, bool Active, int IdCompany)
        {
            this.Id = Id;
            this.Username = Username;
            this.Password = Password;
            this.Active = Active;
            this.IdCompany = IdCompany;
        }

        public int Id { get; private set; }
        public string Username { get; private set; }
        public int Password { get; private set; }
        public bool Active { get; private set; }
        public int IdCompany { get; private set; }
    }
}
