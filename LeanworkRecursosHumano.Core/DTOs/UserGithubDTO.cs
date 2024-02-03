using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LeanworkRecursosHumano.Core.DTOs
{

    public class UserGithubDTO
    {
        public UserGithubDTO(int id, string login, string html_url, string type, string creatredAtFormatted)
        {
            Id = id;
            Login = login;
            Html_url = html_url;
            Type = type;
            CreatredAtFormatted = creatredAtFormatted;
        }

        public int Id { get;  private set; }
        public string Login { get; private set; }
        public string Html_url { get; private set; }
        public string Type { get; private set; }
        public DateTime Created_at { get; set; }        
        public string CreatredAtFormatted { get; private set; }
    }
}
