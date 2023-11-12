using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using App.Security.Data.Entities;
using App.Security.Service.Dtos;

namespace App.Security.Service.IServices
{
    public interface IUserClaimService
    {
        Task<List<UserClaimDTO>> GetUserClaims(Expression<Func<AppUserClaim, bool>> expression);
    }
}
