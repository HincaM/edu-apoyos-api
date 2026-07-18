using EduApoyos.Domain.Common.Helpers;
using EduApoyos.Domain.Models;
using EduApoyos.Domain.Specifications;

namespace EduApoyos.Domain.Repositories
{
    public interface IRequestSupportRepository
    {
        Task<PaginatedList<GetRequestsSupportResult>> GetRequests(GetRequestSupportSpecification specification, CancellationToken cancellationToken);
    }
}
