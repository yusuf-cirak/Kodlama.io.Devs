using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos
{
    public class UpdatedGithubProfileDto
    {
        public string HtmlUrl { get; set; }
        public string Name { get; set; }
        public ushort PublicRepos { get; set; }
        public ushort PublicGists { get; set; }
        public ushort Followers { get; set; }
        public ushort Following { get; set; }
    }
}
