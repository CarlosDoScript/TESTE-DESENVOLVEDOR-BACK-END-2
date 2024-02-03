using LeanworkRecursosHumano.Core.DTOs;
using LeanworkRecursosHumano.Core.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Infrastructure.Github
{
    public class GithubService : IGithubService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _githubBaseUrl;
        private readonly GithubConfig _githubConfig;

        public GithubService(IHttpClientFactory httpClientFactory, IConfiguration configuration, GithubConfig githubConfig)
        {
            _httpClientFactory = httpClientFactory;
            _githubBaseUrl = configuration.GetSection("Services:Github").Value;
            _githubConfig = githubConfig;
        }

        public async Task<GithubUserDTO> GetUserByLoginNameAsync(string userLogin)
        {
            var httpClientFactory = _httpClientFactory.CreateClient();

            httpClientFactory.DefaultRequestHeaders
                .Authorization = new AuthenticationHeaderValue("Bearer", _githubConfig.Key);

            httpClientFactory.DefaultRequestHeaders.
                UserAgent.Add(new ProductInfoHeaderValue("AppName", "1.0"));

            var url = $"{_githubBaseUrl}/users/{userLogin}";

            var response = await httpClientFactory.GetAsync(url);

            GithubUserDTO userGitHubDTO;

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha na requisição: " + response.StatusCode + " - " + response.Content);
            }

            var responseContent = await response
                .Content.ReadAsStringAsync();

            var settings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            userGitHubDTO = JsonConvert
            .DeserializeObject<GithubUserDTO>(responseContent,settings);

            var userGitHubDTOFormatted = new GithubUserDTO(
                userGitHubDTO.Id,
                userGitHubDTO.Login,
                userGitHubDTO.Html_url,
                userGitHubDTO.Type,
                userGitHubDTO.Created_at.ToString("dd/MM/yyyy")
                ) ;

            return userGitHubDTOFormatted;
        }

        public async Task<List<GithubUserDTO>> GetUsersAsync()
        {
            int perPage = 30, page = 1;

            var httpClientFactory = _httpClientFactory.CreateClient();

            httpClientFactory.DefaultRequestHeaders
                .Authorization = new AuthenticationHeaderValue("Bearer", _githubConfig.Key);

            httpClientFactory.DefaultRequestHeaders.
                UserAgent.Add(new ProductInfoHeaderValue("AppName", "1.0"));

            var url = $"{_githubBaseUrl}/users?per_page={perPage}&page={page}";

            var response = await httpClientFactory.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Falha na requisição: " + response.StatusCode + " - " + response.Content);
            }

            var responseContent = await response
                .Content.ReadAsStringAsync();

            var usersGitHubDTO = JsonConvert
            .DeserializeObject<List<GithubUserDTO>>(responseContent);

            return usersGitHubDTO;
        }
    }
}
