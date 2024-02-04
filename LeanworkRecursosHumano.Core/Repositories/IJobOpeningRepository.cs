using LeanworkRecursosHumano.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Core.Repositories
{
    public interface IJobOpeningRepository
    {
        Task<List<JobOpening>> GetAllAsync();
        Task<JobOpening> GetByIdAsync(int id);
        Task<int> PostAsync(string title, string description,DateTime screeningPeriod);
        Task<int> UpdateAsync(int id,string title, string description, DateTime screeningPeriod);
        Task<int> DeleteAsync(int id);
    }
}
