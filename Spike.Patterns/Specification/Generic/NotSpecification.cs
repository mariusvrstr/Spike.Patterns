using System;
using System.Linq;
using System.Linq.Expressions;
using Spike.Patterns.Specification.Generic.Clauses;

namespace Spike.Patterns.Specification.Generic
{
    public sealed class NotSpecification<TEntity> : Clause<TEntity> where TEntity : class
    {
        private readonly Expression<Func<TEntity, bool>> _originalCriteria;

        public NotSpecification(IClause<TEntity> originalSpecification)
        {
            if (originalSpecification == null)
            {
                throw new ArgumentNullException(nameof(originalSpecification));
            }

            _originalCriteria = originalSpecification.SatisfiedBy();
        }

        public NotSpecification(Expression<Func<TEntity, bool>> originalSpecification)
        {
            _originalCriteria = originalSpecification ?? throw new ArgumentNullException(nameof(originalSpecification));
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return Expression.Lambda<Func<TEntity, bool>>(Expression.Not(_originalCriteria.Body), _originalCriteria.Parameters.Single());
        }
    }
}
