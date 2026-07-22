using EduApoyos.Domain.Entities;
using System.Linq.Expressions;

namespace EduApoyos.Domain.Specifications.Students
{
    public class GetStudentByIdSpecification : ISpecification<Student>
    {
        public Expression<Func<Student, bool>> Criteria { get; internal set; }

        public GetStudentByIdSpecification(int studentId) 
        {
            Criteria = x => x.Id == studentId;
        }

    }
}
