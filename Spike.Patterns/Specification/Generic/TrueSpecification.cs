using System;
using System.Linq.Expressions;
using Spike.Patterns.Specification.Generic.Clauses;

namespace Spike.Patterns.Specification.Generic
{
    public sealed class TrueSpecification<TEntity> : Clause<TEntity> where TEntity : class
    {
        public override Expression<Func<TEntity, bool>> SatisfiedBy() => t => true;
    }
}

