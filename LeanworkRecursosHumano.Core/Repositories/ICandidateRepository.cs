using LeanworkRecursosHumano.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Core.Repositories
{
    public interface ICandidateRepository
    {
        Task<List<Candidate>> GetAllAsync();
        Task<Candidate> GetByIdAsync(int id);
        Task<int> PostAsync(string name, string email,string cellPhone);
        Task<int> UpdateAsync(int id,string name, string email, string cellPhone);
        Task<int> DeleteAsync(int id);
    }
}
