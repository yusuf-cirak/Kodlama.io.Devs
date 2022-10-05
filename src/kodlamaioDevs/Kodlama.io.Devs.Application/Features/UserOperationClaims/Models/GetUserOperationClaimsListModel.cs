using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Models
{
    public class GetUserOperationClaimsListModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public IList<UserOperationClaimDto> UserOperationClaimsDtoList { get; set; }
    }
}
