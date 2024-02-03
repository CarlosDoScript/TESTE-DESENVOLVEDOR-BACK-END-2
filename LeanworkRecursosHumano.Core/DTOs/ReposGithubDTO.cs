using System;
using System.Collections.Generic;
using System.Text;

namespace LeanworkRecursosHumano.Core.DTOs
{
    public class ReposGithubDTO
    {
        public ReposGithubDTO(int id, string name, string html_url)
        {
            Id = id;
            Name = name;
            Html_url = html_url;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Html_url { get; private set; }
    }
}
