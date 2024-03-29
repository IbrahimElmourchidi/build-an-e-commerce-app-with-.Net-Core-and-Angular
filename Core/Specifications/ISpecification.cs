using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications;

public interface ISpecification<TEntity> where TEntity : BaseEntity
{
    Expression<Func<TEntity, bool>> Criteria { get; }
    List<Expression<Func<TEntity, object>>> Includes { get; }
}
