namespace Spike.Patterns.Specification.Generic.Clauses
{
    public abstract class CompositeClause<TEntity> : Clause<TEntity> where TEntity : class
    {
        public abstract IClause<TEntity> LeftSideSpecification
        {
            get;
        }

        public abstract IClause<TEntity> RightSideSpecification
        {
            get;
        }
    }
}
