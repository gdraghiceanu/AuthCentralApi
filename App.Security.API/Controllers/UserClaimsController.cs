using App.Security.Helper;
using App.Security.Service.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Security.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClaimsController : ControllerBase
    {
        private readonly IUserClaimService _userClaimServices;

        public UserClaimsController(IUserClaimService userClaimServices)
        {
            _userClaimServices = userClaimServices;
        }

        [HttpGet("GetAdminClaims")]
        public async Task<IActionResult> GetAdminClaims()
        {
            var result = await _userClaimServices.GetUserClaims(e => e.ClaimType == Constants.ROLE_ADMIN);
            return Ok(result);
        }

        [HttpGet("GetUserClaims")]
        public async Task<IActionResult> GetUserClaims()
        {
            var result = await _userClaimServices.GetUserClaims(e => e.ClaimType == Constants.ROLE_USER);
            return Ok(result);
        }
    }
}
