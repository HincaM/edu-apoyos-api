using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Entities;
using System.Linq.Expressions;

namespace EduApoyos.Domain.Specifications.Users
{
    public class GetAdvisorsSpecification : ISpecification<User>
    {
        public int CurrentPage { get; internal set; }
        public int PageSize { get; internal set; }
        public Expression<Func<User, object>> OrderBy { get; internal set; }
        public Expression<Func<User, bool>> Criteria { get; internal set; }
        public GetAdvisorsSpecification(int currentPage, int pageSize)
        {
            Criteria = x => x.Role == Role.Advisor;
            CurrentPage = currentPage;
            PageSize = pageSize;
            OrderBy = x => x.FullName;
        }
    }
}
