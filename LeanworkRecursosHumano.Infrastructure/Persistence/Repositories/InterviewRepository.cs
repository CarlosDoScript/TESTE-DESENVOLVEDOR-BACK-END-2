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
using System.Xml.Linq;

namespace LeanworkRecursosHumano.Infrastructure.Persistence.Repositories
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly string _connectionString;

        public InterviewRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LeanworkRecursosHumanoCs");
        }

        public async Task<List<InterviewCandidateDTO>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT c.Name AS NameCandidate, J.Title AS TitleJobOpening, J.Description AS DescriptionJobOpening, CJ.IdCandidate, CJ.IdJobOpening FROM Candidate C LEFT JOIN CandidateJobOpening CJ ON C.Id = CJ.IdCandidate LEFT JOIN JobOpening J ON J.Id = CJ.IdJobOpening WHERE CJ.Active = 1";

                return (await sqlConnection.QueryAsync<InterviewCandidateDTO>(script)).ToList();
            }
        }

        public async Task<InterviewCandidateDTO> GetByIdCandidateAsync(int idCandidate)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT c.Name AS NameCandidate, J.Title AS TitleJobOpening, J.Description AS DescriptionJobOpening, CJ.IdCandidate, CJ.IdJobOpening FROM Candidate C LEFT JOIN CandidateJobOpening CJ ON C.Id = CJ.IdCandidate LEFT JOIN JobOpening J ON J.Id = CJ.IdJobOpening WHERE CJ.IdCandidate = @idCandidate AND CJ.Active = 1";

                return (await sqlConnection.QueryAsync<InterviewCandidateDTO>(script, new { idCandidate })).SingleOrDefault();
            }
        }

        public async Task<int> PostAsync(int idCandidate, int idJobOpening)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "INSERT INTO CandidateJobOpening (IdCandidate,IdJobOpening,Active) VALUES(@idCandidate,@IdJobOpening,1)";

                await sqlConnection.QueryFirstOrDefaultAsync<int>(script, new { idCandidate, idJobOpening });

                var scriptUpdateCandidate = "UPDATE Candidate SET IdJobOpening = @idJobOpening WHERE Id = @idCandidate";

                await sqlConnection.ExecuteAsync(scriptUpdateCandidate, new { idJobOpening, idCandidate });

                return idCandidate;
            }
        }

        public async Task<int> DeleteAsync(int idCandidate)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE CandidateJobOpening SET Active = 0 WHERE IdCandidate = @idCandidate";

                return (await sqlConnection.ExecuteAsync(script, new { idCandidate }));
            }
        }

        public async Task<int> UpdateAsync(int idCandidate, int idJobOpening)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE CandidateJobOpening SET IdJobOpening = @idJobOpening WHERE IdCandidate = @idCandidate AND Active = 1";

                return (await sqlConnection.ExecuteAsync(script, new { idCandidate, idJobOpening }));
            }
        }
    }
}
