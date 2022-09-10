using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos
{
    public class ReceivedGithubProfileDto
    {
        public string Login { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }

        public string Name { get; set; }
        public string Company { get; set; }
        public string Blog { get; set; }
        public string Location { get; set; }


        [JsonPropertyName("public_repos")]
        public ushort PublicRepos { get; set; }

        public ushort Followers { get; set; }
        public ushort Following { get; set; }
    }
}
