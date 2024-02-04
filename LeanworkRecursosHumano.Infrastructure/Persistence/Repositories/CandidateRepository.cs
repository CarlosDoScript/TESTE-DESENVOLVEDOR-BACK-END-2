using Dapper;
using LeanworkRecursosHumano.Core.Entities;
using LeanworkRecursosHumano.Core.Repositories;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Infrastructure.Persistence.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {

        private readonly string _connectionString;

        public CandidateRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LeanworkRecursosHumanoCs");
        }

        public async Task<List<Candidate>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT * FROM Candidate WHERE Active = 1";

                return (await sqlConnection.QueryAsync<Candidate>(script)).ToList();
            }
        }

        public async Task<Candidate> GetByIdAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT * FROM Candidate WHERE Id = @id AND Active = 1";

                return (await sqlConnection.QueryAsync<Candidate>(script, new { id = id })).SingleOrDefault();

            }
        }

        public async Task<int> PostAsync(string name, string email, string cellPhone)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "INSERT INTO Candidate (Name,Email,CellPhone,Active) VALUES(@name,@email,@cellPhone,1) SELECT SCOPE_IDENTITY()";

                return await sqlConnection.QueryFirstOrDefaultAsync<int>(script, new { name, email, cellPhone });
            }
        }

        public async Task<int> UpdateAsync(int id,string name, string email, string cellPhone)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Candidate SET Name = @name, Email = @email, CellPhone = @cellPhone WHERE Id = @id AND Active = 1";

                return (await sqlConnection.ExecuteAsync(script, new {id, name, email, cellPhone}));

            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Candidate SET Active = 0 WHERE Id = @id";

                return (await sqlConnection.ExecuteAsync(script, new { id }));
            }
        }
    }
}
