using System;
using System.Linq.Expressions;

namespace Spike.Patterns.Specification.Generic.Clauses
{
    public sealed class DirectClause<TEntity> : Clause<TEntity> where TEntity : class
    {
        private readonly Expression<Func<TEntity, bool>> _matchingCriteria;

        public DirectClause(Expression<Func<TEntity, bool>> matchingCriteria)
        {
            _matchingCriteria = matchingCriteria ?? throw new ArgumentNullException(nameof(matchingCriteria));
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return _matchingCriteria;
        }
    }
}
