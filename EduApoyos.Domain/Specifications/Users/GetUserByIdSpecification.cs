using EduApoyos.Domain.Entities;
using System.Linq.Expressions;

namespace EduApoyos.Domain.Specifications.Users
{
    public class GetUserByIdSpecification : ISpecification<User>
    {
        public Expression<Func<User, bool>> Criteria { get; internal set; }

        public GetUserByIdSpecification(int userId)
        {
            Criteria = x => x.Id == userId;
        }
    }
}
