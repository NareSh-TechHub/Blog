using BlogApp.API.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class AdminOperationsController(UserManager<IdentityUser> userManager) 
        : ControllerBase
    {

        [HttpGet("PendingCreatorRequests")]
        public async Task<IList<CreatorAccessRequestDto>> GetPendingCreatorAccessRequests()
        {
            var usersWithClaim = await userManager.GetUsersForClaimAsync(
                new Claim("creator_request", "true"));

            var pendingRequests = new List<CreatorAccessRequestDto>();

            foreach (var user in usersWithClaim)
            {
                var roles = await userManager.GetRolesAsync(user);
                if (!roles.Contains("Creator"))
                {
                    var claims = await userManager.GetClaimsAsync(user);
                    var requestedAtClaim = claims.FirstOrDefault(c => c.Type == "creator_requested_at");

                    DateTimeOffset requestedAt = DateTimeOffset.UtcNow;
                    if (requestedAtClaim != null 
                        && DateTimeOffset.TryParse(requestedAtClaim.Value, out var parsedDate))
                    {
                        requestedAt = parsedDate;
                    }

                    pendingRequests.Add(new CreatorAccessRequestDto
                    {
                        UserId = user.Id,
                        UserName = user.UserName!,
                        RequestedAt = requestedAt
                    });
                }
            }

            return pendingRequests;
        }


        [HttpPost("HandleCreatorAccessRequest")]
        public async Task<IActionResult> HandleCreatorAccessRequest(string userId, bool isApproved)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var claims = await userManager.GetClaimsAsync(user);
            var hasRequest = claims.Any(c => c.Type == "creator_request" && c.Value == "true");
            if (!hasRequest)
            {
                return BadRequest(new { message = "No pending creator access request found" });
            }

            if (isApproved)
            {
                await userManager.AddToRoleAsync(user, "Creator");
                //TODO: server-side token invalidation and refresh mechanism - For Phase 2
            }

            await RemoveCreatorRequestClaim(user);

            return Ok(new
            {
                message = isApproved ? "Creator access granted" : "Creator access denied",
                userId = user.Id,
                email = user.Email,
                approved = isApproved
            });
        }

        private async Task RemoveCreatorRequestClaim(IdentityUser user)
        {
            await userManager.RemoveClaimAsync(user, new Claim("creator_request", "true"));

            var claims = await userManager.GetClaimsAsync(user);
            var timestampClaim = claims.FirstOrDefault(c => c.Type == "creator_requested_at");
            if (timestampClaim != null)
            {
                await userManager.RemoveClaimAsync(user, timestampClaim);
            }
        }
    }
}
