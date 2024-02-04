using Dapper;
using LeanworkRecursosHumano.Core.DTOs;
using LeanworkRecursosHumano.Core.Entities;
using LeanworkRecursosHumano.Core.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Infrastructure.Persistence.Repositories
{
    public class TechnologyJobOpeningRepository : ITechnologyJobOpeningRepository
    {
        private readonly string _connectionString;

        public TechnologyJobOpeningRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LeanworkRecursosHumanoCs");
        }

        public async Task<List<TechnologyJobOpeningDTO>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT JO.Title AS TitleJobOpening, JO.Description AS DescriptionJobOpening, T.Name AS NameTechnology, T.Description AS DescriptionTechnology, JT.IdJobOpening, JT.IdTechnology FROM JobOpening JO LEFT JOIN JobOpeningTechnology JT ON JT.IdJobOpening = JO.Id LEFT JOIN Technology T ON T.Id = JT.IdTechnology WHERE JT.Active = 1";

                return (await sqlConnection.QueryAsync<TechnologyJobOpeningDTO>(script)).ToList();
            }
        }

        public async Task<List<TechnologyJobOpeningDTO>> GetByIdJobOpeningAsync(int idJobOpening)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT JO.Title AS TitleJobOpening, JO.Description AS DescriptionJobOpening, T.Name AS NameTechnology, T.Description AS DescriptionTechnology, JT.IdJobOpening, JT.IdTechnology FROM JobOpening JO LEFT JOIN JobOpeningTechnology JT ON JT.IdJobOpening = JO.Id LEFT JOIN Technology T ON T.Id = JT.IdTechnology WHERE JT.IdJobOpening = @idJobOpening AND JT.Active = 1";

                return (await sqlConnection.QueryAsync<TechnologyJobOpeningDTO>(script, new { idJobOpening })).ToList();
            }
        }
  
        public async Task<int> PostAsync(int idJobOpening, int idTechnology)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "INSERT INTO JobOpeningTechnology (IdJobOpening,IdTechnology,Active) VALUES(@idJobOpening,@idTechnology,1)";

                await sqlConnection.QueryFirstOrDefaultAsync<int>(script, new { idJobOpening, idTechnology });

                return idJobOpening;
            }
        }

        public async Task<int> UpdateAsync(int idJobOpening, int idTechnology)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE JobOpeningTechnology SET IdJobOpening = @idJobOpening WHERE IdTechnology = @idTechnology AND Active = 1";

                return (await sqlConnection.ExecuteAsync(script, new { idJobOpening, idTechnology }));
            }
        }
        public async Task<int> DeleteAsync(int idJobOpening)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE JobOpeningTechnology SET Active = 0 WHERE IdJobOpening = @idJobOpening";

                return (await sqlConnection.ExecuteAsync(script, new { idJobOpening }));
            }
        }

    }
}
