using System;
using System.Linq.Expressions;

namespace Spike.Patterns.Specification.Generic.Clauses
{
    public interface IClause<TEntity> where TEntity : class
    {
        Expression<Func<TEntity, bool>> SatisfiedBy();

        IClause<TEntity> And(IClause<TEntity> clause);

        // IClause<TEntity> Not();

        IClause<TEntity> Or(IClause<TEntity> clause);
    }
}
