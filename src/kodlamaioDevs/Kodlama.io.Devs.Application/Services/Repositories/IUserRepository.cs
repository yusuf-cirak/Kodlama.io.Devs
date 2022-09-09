using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories
{
    public interface IUserRepository:IAsyncRepository<User>
    {
    }
}
