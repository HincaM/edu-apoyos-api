using EduApoyos.Domain.Common.Enums;

namespace EduApoyos.Domain.Models
{
    public record GetRequestsSupportRequest(Status? Status, TypeSupport? Type, int CurrentPage, int PageSize);
}
