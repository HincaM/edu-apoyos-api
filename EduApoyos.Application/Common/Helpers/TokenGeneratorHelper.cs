using EduApoyos.Application.Common.Helpers;
using EduApoyos.Application.Extensions;
using EduApoyos.Domain.Common.Enums;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EduApoyos.Application.Helpers
{
    public sealed class TokenGeneratorHelper(IOptions<TokenOption> _options)
    {
        private readonly TokenOption _tokenOption = _options.Value;
        public string Generate(int userId, string email, Role role)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, userId.ToString()),
                new(ClaimTypes.Email, email),
                new(ClaimTypes.Role, role.GetDescription())
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOption.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                issuer: _tokenOption.Issuer,
                audience: _tokenOption.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(_tokenOption.ExpireMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
