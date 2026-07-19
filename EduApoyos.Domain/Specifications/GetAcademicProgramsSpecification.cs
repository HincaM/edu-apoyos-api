using EduApoyos.Domain.Entities;
using System.Linq.Expressions;

namespace EduApoyos.Domain.Specifications
{
    public class GetAcademicProgramsSpecification : ISpecification<AcademicProgram>
    {
        public int CurrentPage { get; internal set; }
        public int PageSize { get; internal set; }
        public Expression<Func<AcademicProgram, object>> OrderBy { get; internal set; }
        public Expression<Func<AcademicProgram, bool>> Criteria { get; internal set; }
        public GetAcademicProgramsSpecification(int currentPage, int pageSize)
        {
            Criteria = x => true;
            CurrentPage = currentPage;
            PageSize = pageSize;
            OrderBy = x => x.Name;
        }
    }
}
