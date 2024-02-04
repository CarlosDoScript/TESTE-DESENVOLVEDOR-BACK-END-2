using LeanworkRecursosHumano.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Core.Repositories
{
    public interface IPersonRHRepository
    {
        Task<PersonRH> GetPersonByNameLoginAndPasswordAsync(string nameLogin, string password);
    }
}
