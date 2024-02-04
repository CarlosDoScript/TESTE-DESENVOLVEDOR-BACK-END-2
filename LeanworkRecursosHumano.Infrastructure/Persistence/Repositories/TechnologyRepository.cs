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

namespace LeanworkRecursosHumano.Infrastructure.Persistence.Repositories
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly string _connectionString;

        public TechnologyRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LeanworkRecursosHumanoCs");
        }

        public async Task<List<Technology>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT * FROM Technology WHERE Active = 1";

                return (await sqlConnection.QueryAsync<Technology>(script)).ToList();
            }
        }

        public async Task<Technology> GetByIdAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT * FROM Technology WHERE Id = @id AND Active = 1";

                return (await sqlConnection.QueryAsync<Technology>(script, new { id = id })).SingleOrDefault();

            }
        }

        public async Task<int> PostAsync(string name, string description, int weight)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "INSERT INTO Technology (Name,Description,Weight,Active) VALUES(@name,@description,@weight,1) SELECT SCOPE_IDENTITY()";

                return await sqlConnection.QueryFirstOrDefaultAsync<int>(script, new { name, description, weight });
            }
        }

        public async Task<int> UpdateAsync(int id, string name, string description, int weight)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Technology SET Name = @name, Description = @description, Weight = @weight WHERE Id = @id AND Active = 1";

                return (await sqlConnection.ExecuteAsync(script, new { id = id, name = name, description = description, weight = weight }));

            }
        }
        public async Task<int> DeleteAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Technology SET Active = 0 WHERE Id = @id";

                return (await sqlConnection.ExecuteAsync(script, new { id = id }));

            }
        }
    }
}
