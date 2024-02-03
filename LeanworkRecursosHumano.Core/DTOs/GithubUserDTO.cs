using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Core.DTOs
{
    public class GithubUserDTO
    {
        public GithubUserDTO(int id, string login, string url, string type)
        {
            Id = id; 
            Login = login;
            Url = url;
            Type = type;
        }

        public int Id { get; private set; }
        public string Login { get; private set; }
        public string Url { get; private set; }
        public string Type { get; private set; }
    }
}
