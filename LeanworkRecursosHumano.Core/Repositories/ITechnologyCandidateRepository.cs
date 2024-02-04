using LeanworkRecursosHumano.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Core.Repositories
{
    public interface ITechnologyCandidateRepository
    {
        Task<List<TechnologyCandidateDTO>> GetAllAsync();
        Task<List<TechnologyCandidateDTO>> GetByIdCandidateAsync(int idCandidate);
        Task<int> PostAsync(int idCandidate, int idTechnology);
        Task<int> DeleteAsync(int idCandidate);
        Task<int> UpdateAsync(int idCandidate, int idTechnology);
    }
}
