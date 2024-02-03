﻿using LeanworkRecursosHumano.Core.DTOs;
using LeanworkRecursosHumano.Core.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            List<GithubUserDTO> usersGitHubDTO = new List<GithubUserDTO>();

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response
                    .Content.ReadAsStringAsync();

                usersGitHubDTO = JsonConvert
                .DeserializeObject<List<GithubUserDTO>>(responseContent);

                return usersGitHubDTO;
            }
            
            return usersGitHubDTO;
        }
    }
}
