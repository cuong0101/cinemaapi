using CinemaManagement.DTOs;
using CinemaManagement.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace CinemaManagement.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
