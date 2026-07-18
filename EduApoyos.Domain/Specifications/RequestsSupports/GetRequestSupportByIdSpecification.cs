using EduApoyos.Domain.Entities;
using System.Linq.Expressions;

namespace EduApoyos.Domain.Specifications.RequestsSupports
{
    public sealed class GetRequestSupportByIdSpecification : ISpecification<RequestSupport>
    {
        public Expression<Func<RequestSupport, bool>> Criteria { get; internal set; }

        public GetRequestSupportByIdSpecification(int id)
        {
            Criteria = x => x.Id == id;
        }
    }
}
