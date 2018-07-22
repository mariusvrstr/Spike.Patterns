using System;
using System.Linq.Expressions;
using Spike.Patterns.Specification.Generic.Clauses;

namespace Spike.Patterns.Specification.Generic
{
    public class OrSpecification<TEntity> : CompositeClause<TEntity>
        where TEntity : class
    {
        private readonly IClause<TEntity> _left;
        private readonly IClause<TEntity> _right;

        public OrSpecification(IClause<TEntity> left, IClause<TEntity> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            var leftExpression = _left.SatisfiedBy();
            var rightExpression = _right.SatisfiedBy();

            var parameter = Expression.Parameter(typeof(TEntity));

            var leftVisitor = new ReplaceExpressionVisitor(leftExpression.Parameters[0], parameter);
            var left = leftVisitor.Visit(leftExpression.Body);

            var rightVisitor = new ReplaceExpressionVisitor(rightExpression.Parameters[0], parameter);
            var right = rightVisitor.Visit(rightExpression.Body);

            return Expression.Lambda<Func<TEntity, bool>>(
                Expression.OrElse(left, right), parameter);
        }

        public override IClause<TEntity> LeftSideSpecification { get; }
        public override IClause<TEntity> RightSideSpecification { get; }
    }
}
