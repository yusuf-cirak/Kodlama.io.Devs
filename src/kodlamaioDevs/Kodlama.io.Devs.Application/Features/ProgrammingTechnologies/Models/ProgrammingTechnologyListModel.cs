using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models
{
    public class ProgrammingTechnologyListModel:BasePageableModel
    {
        public IList<ProgrammingTechnologyListDto> Items { get; set; }
    }
}
