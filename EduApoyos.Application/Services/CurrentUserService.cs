using EduApoyos.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EduApoyos.Application.Services
{
    public class CurrentUserService(IHttpContextAccessor _httpContextAccessor) : ICurrentUserService
    {
        public int UserId => int.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name) ?? "0");
    }
}
