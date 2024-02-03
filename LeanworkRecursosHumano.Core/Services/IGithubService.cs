﻿using LeanworkRecursosHumano.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeanworkRecursosHumano.Core.Services
{
    public interface IGithubService
    {
        Task<List<GithubUserDTO>> GetUsersAsync(string filter, int perPage, int page = 1);
    }
}