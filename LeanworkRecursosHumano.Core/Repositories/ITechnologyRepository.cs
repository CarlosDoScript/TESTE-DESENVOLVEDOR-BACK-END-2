using LeanworkRecursosHumano.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Core.Repositories
{
    public interface ITechnologyRepository
    {
        Task<List<Technology>> GetAllAsync();
        Task<Technology> GetByIdAsync(int id);
        Task<int> PostAsync(string name, string description, int weight);
        Task<int> UpdateAsync(int id, string name, string description, int weight);
        Task<int> DeleteAsync(int id);
    }
}
