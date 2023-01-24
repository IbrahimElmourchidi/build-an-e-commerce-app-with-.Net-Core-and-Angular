using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications;

public interface ISpecification<TEntity> where TEntity : BaseEntity
{
    public Expression<Func<TEntity, bool>> Criteria { get; }

    public List<Expression<Func<TEntity, object>>> Includes { get; }
}
