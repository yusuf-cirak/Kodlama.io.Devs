using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class GithubProfile:Entity
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string HtmlUrl { get; set; }
        public string Name { get; set; }
        public string? Company { get; set; }
        public string Blog { get; set; }
        public string? Location { get; set; }
        public ushort PublicRepos { get; set; }
        public ushort Followers { get; set; }
        public ushort Following { get; set; }


        public virtual User User { get; set; }

        public GithubProfile()
        {
            
        }

        public GithubProfile(int id, int userId, string htmlUrl, string name, string company, string blog, string location, ushort publicRepos, ushort followers, ushort following)
        {
            Id = id;
            UserId = userId;
            HtmlUrl = htmlUrl;
            Name = name;
            Company = company;
            Blog = blog;
            Location = location;
            PublicRepos = publicRepos;
            Followers = followers;
            Following = following;
        }
    }
}
