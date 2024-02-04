using Dapper;
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
    public class JobOpeningRepository : IJobOpeningRepository
    {
        private readonly string _connectionString;

        public JobOpeningRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LeanworkRecursosHumanoCs");
        }

        public async Task<List<JobOpening>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT * FROM JobOpening WHERE Active = 1";

                return (await sqlConnection.QueryAsync<JobOpening>(script)).ToList();
            }
        }

        public async Task<JobOpening> GetByIdAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT * FROM JobOpening WHERE Id = @id AND Active = 1";

                return (await sqlConnection.QueryAsync<JobOpening>(script, new { id = id })).SingleOrDefault();

            }
        }
        public async Task<int> PostAsync(string title, string description, DateTime screeningPeriod)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "INSERT INTO JobOpening (Title,Description,ScreeningPeriod,Active) VALUES(@title,@description,@screeningPeriod,1) SELECT SCOPE_IDENTITY()";

                return await sqlConnection.QueryFirstOrDefaultAsync<int>(script, new { title, description, screeningPeriod });
            }
        }
        public async Task<int> UpdateAsync(int id,string title, string description, DateTime screeningPeriod)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE JobOpening SET Title = @title, Description = @description, ScreeningPeriod = @screeningPeriod WHERE Id = @id AND Active = 1";

                return (await sqlConnection.ExecuteAsync(script, new {title,description,screeningPeriod}));

            }
        }
        public async Task<int> DeleteAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE JobOpening SET Active = 0 WHERE Id = @id";

                return (await sqlConnection.ExecuteAsync(script, new { id }));

            }
        }
    }
}
