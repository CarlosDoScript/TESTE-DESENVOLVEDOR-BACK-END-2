using LeanworkRecursosHumano.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Core.Repositories
{
    public interface ITechnologyJobOpeningRepository
    {
        Task<List<TechnologyJobOpeningDTO>> GetAllAsync();
        Task<List<TechnologyJobOpeningDTO>> GetByIdJobOpeningAsync(int idJobOpening);
        Task<int> PostAsync(int idJobOpening, int idTechnology);
        Task<int> UpdateAsync(int idJobOpening, int idTechnology);
        Task<int> DeleteAsync(int idJobOpening);
    }
}
