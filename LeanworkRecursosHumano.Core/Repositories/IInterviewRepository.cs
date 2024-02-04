using LeanworkRecursosHumano.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Core.Repositories
{
    public interface IInterviewRepository
    {
        Task<List<InterviewCandidateDTO>> GetAllAsync();
        Task<InterviewCandidateDTO> GetByIdCandidateAsync(int idCandidate);
        Task<int> PostAsync(int idCandidate,int idJobOpening);
        Task<int> DeleteAsync(int idCandidate);
        Task<int> UpdateAsync(int idCandidate, int idJobOpening);
    }
}
