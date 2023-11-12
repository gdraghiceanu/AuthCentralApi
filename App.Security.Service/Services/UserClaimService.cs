using App.Security.Data;
using App.Security.Data.Entities;
using App.Security.Service.Dtos;
using App.Security.Service.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.Security.Service.Services
{
    public class UserClaimService : IUserClaimService
    {
        private readonly AppDbContext _appDbContext;

        public UserClaimService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<UserClaimDTO>> GetUserClaims(Expression<Func<AppUserClaim, bool>> expression)
        {
            try
            {
                var result = await (from claim in _appDbContext.AppUserClaim.Where(expression)
                                    select new UserClaimDTO()
                                    {
                                        ClaimType = claim.ClaimType,
                                        ClaimValue = claim.ClaimValue
                                    }).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
