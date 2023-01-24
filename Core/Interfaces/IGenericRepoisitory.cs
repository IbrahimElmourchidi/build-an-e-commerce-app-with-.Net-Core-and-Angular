using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetSingle(int id);
    Task<TEntity?> GetSingleWithSpec(ISpecification<TEntity> spec);
    Task<IReadOnlyList<TEntity>> ListAllAsync();
    Task<IReadOnlyList<TEntity>> ListAllAsyncWithSpec(ISpecification<TEntity> spec);
}
