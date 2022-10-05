using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Models
{
    public class OperationClaimListModel // no need to paginate
    {
        public IList<OperationClaimDto> Items { get; set; }
    }
}
