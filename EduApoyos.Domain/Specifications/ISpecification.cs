using System.Linq.Expressions;

namespace EduApoyos.Domain.Specifications
{
    public interface ISpecification<TEntity>
    {
        Expression<Func<TEntity, bool>> Criteria { get; }
    }
}
