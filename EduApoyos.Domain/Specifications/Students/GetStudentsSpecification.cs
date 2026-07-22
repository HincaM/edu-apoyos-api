using EduApoyos.Domain.Entities;
using System.Linq.Expressions;

namespace EduApoyos.Domain.Specifications.Students
{
    public class GetStudentsSpecification(int currentPage, int pageSize) 
    {
        public int CurrentPage { get; } = currentPage;
        public int PageSize { get; } = pageSize;
        public Expression<Func<Student, object>> OrderBy = x => x.User != null ? x.User.FullName : "";
    }
}
