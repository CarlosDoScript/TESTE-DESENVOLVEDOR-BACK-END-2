using Dapper;
using LeanworkRecursosHumano.Core.Entities;
using LeanworkRecursosHumano.Core.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Infrastructure.Persistence.Repositories
{
    public class PersonRHRepository : IPersonRHRepository
    {
        private readonly string _connectionString;

        public PersonRHRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LeanworkRecursosHumanoCs");
        }

        public async Task<PersonRH> GetPersonByNameLoginAndPasswordAsync(string nameLogin, string password)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT * FROM RHPeople WHERE Username = @username AND Password = @password";

                return (await sqlConnection.QueryAsync<PersonRH>(script, new { username = nameLogin, password = password })).SingleOrDefault();
            }
        }
    }
}
