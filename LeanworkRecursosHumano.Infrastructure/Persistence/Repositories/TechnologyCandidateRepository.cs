using Dapper;
using LeanworkRecursosHumano.Core.DTOs;
using LeanworkRecursosHumano.Core.Entities;
using LeanworkRecursosHumano.Core.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Infrastructure.Persistence.Repositories
{
    public class TechnologyCandidateRepository : ITechnologyCandidateRepository
    {
        private readonly string _connectionString;

        public TechnologyCandidateRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LeanworkRecursosHumanoCs");
        }

        public async Task<List<TechnologyCandidateDTO>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT c.Name AS NameCandidate, T.Name AS NameTechnology, T.Description AS DescriptionTechnology, CT.IdCandidate, CT.IdTechnology FROM Candidate C LEFT JOIN CandidateTechnology CT ON C.Id = CT.IdCandidate LEFT JOIN Technology T ON T.Id = CT.IdTechnology WHERE CT.Active = 1";

                return (await sqlConnection.QueryAsync<TechnologyCandidateDTO>(script)).ToList();
            }
        }

        public async Task<List<TechnologyCandidateDTO>> GetByIdCandidateAsync(int idCandidate)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT c.Name AS NameCandidate, T.Name AS NameTechnology, T.Description AS DescriptionTechnology, CT.IdCandidate, CT.IdTechnology FROM Candidate C LEFT JOIN CandidateTechnology CT ON C.Id = CT.IdCandidate LEFT JOIN Technology T ON T.Id = CT.IdTechnology WHERE CT.IdCandidate = @idCandidate AND CT.Active = 1";

                return (await sqlConnection.QueryAsync<TechnologyCandidateDTO>(script, new { idCandidate })).ToList();
            }
        }
        public async Task<int> PostAsync(int idCandidate, int idTechnology)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "INSERT INTO CandidateTechnology (IdCandidate,IdTechnology,Active) VALUES(@idCandidate,@idTechnology,1)";

                await sqlConnection.QueryFirstOrDefaultAsync<int>(script, new { idCandidate, idTechnology });
                
                return idCandidate;
            }
        }

        public async Task<int> UpdateAsync(int idCandidate, int idTechnology)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE CandidateJobOpening SET IdTechnology = @idTechnology WHERE IdCandidate = @idCandidate AND Active = 1";

                return (await sqlConnection.ExecuteAsync(script, new { idCandidate, idTechnology }));
            }
        }

        public async Task<int> DeleteAsync(int idCandidate)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE CandidateTechnology SET Active = 0 WHERE IdCandidate = @idCandidate";

                return (await sqlConnection.ExecuteAsync(script, new { idCandidate }));
            }
        }
    }
}
