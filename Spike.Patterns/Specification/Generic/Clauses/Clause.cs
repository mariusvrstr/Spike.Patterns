using System;
using System.Linq.Expressions;

namespace Spike.Patterns.Specification.Generic.Clauses
{
    public abstract class Clause<TEntity> : IClause<TEntity> 
        where TEntity : class
    {
        public abstract Expression<Func<TEntity, bool>> SatisfiedBy();

        public IClause<TEntity> And(IClause<TEntity> clause)
        {
            return new AndSpecification<TEntity>(this, clause);
        }

        public IClause<TEntity> Or(IClause<TEntity> clause)
        {
            return new OrSpecification<TEntity>(this, clause);
        }

        public IClause<TEntity> Not()
        {
            return new NotSpecification<TEntity>(this);
        }

        public static Clause<TEntity> operator &(Clause<TEntity> leftSideSpecification, Clause<TEntity> rightSideSpecification)
        {
            return new AndSpecification<TEntity>(leftSideSpecification, rightSideSpecification);
        }

        public static Clause<TEntity> operator |(Clause<TEntity> leftSideSpecification, Clause<TEntity> rightSideSpecification)
        {
            return new OrSpecification<TEntity>(leftSideSpecification, rightSideSpecification);
        }

        public static Clause<TEntity> operator !(Clause<TEntity> specification)
        {
            return new NotSpecification<TEntity>(specification);
        }

        public static bool operator false(Clause<TEntity> clause)
        {
            return false;
        }

        public static bool operator true(Clause<TEntity> clause)
        {
            return false;
        }

        public bool SatisfiedBy(TEntity t)
        {
            return SatisfiedBy().Compile()(t);
        }
    }
}
