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
        public async Task<List<GithubUsuarioDTO>> GetUsuariosAsync(string filter = null, int perPage = 50, int page = 1)
        {
            var httpClientFactory = _httpClientFactory.CreateClient();

            httpClientFactory.DefaultRequestHeaders
                .Authorization = new AuthenticationHeaderValue("Bearer", _githubConfig.Key);

            httpClientFactory.DefaultRequestHeaders.
                UserAgent.Add(new ProductInfoHeaderValue("AppName", "1.0"));

            if (!string.IsNullOrEmpty(filter))
            {
                var usuarioUrl = $"{_githubBaseUrl}/users/{filter}";
                var responseUser = await httpClientFactory.GetAsync(usuarioUrl);

                if (responseUser.IsSuccessStatusCode)
                {
                    var usuarioContent = await responseUser.Content.ReadAsStringAsync();
                    var githubUsuario = JsonConvert.DeserializeObject<GithubUsuarioDTO>(usuarioContent);

                    return new List<GithubUsuarioDTO> { githubUsuario };
                }
                else
                {
                    return new List<GithubUsuarioDTO>();
                }
            }
            else
            {
                var url = $"{_githubBaseUrl}/users?per_page={perPage}&page={page}";

                var response = await httpClientFactory.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response
                        .Content.ReadAsStringAsync();

                    var githubUsuarioDTO = JsonConvert
                    .DeserializeObject<List<GithubUsuarioDTO>>(responseContent);

                    return githubUsuarioDTO;
                }
                else
                {
                    return new List<GithubUsuarioDTO>();
                }
            }
        }
    }
}
