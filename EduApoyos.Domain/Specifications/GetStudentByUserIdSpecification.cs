using EduApoyos.Domain.Entities;
using System.Linq.Expressions;

namespace EduApoyos.Domain.Specifications
{
    public class GetStudentByUserIdSpecification : ISpecification<Student>
    {
        public Expression<Func<Student, bool>> Criteria { get; internal set; }

        public GetStudentByUserIdSpecification(int userId) 
        {
            Criteria = x => x.User.Id == userId;
        }

    }
}
