using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Spike.Patterns.Specification.Generic.Clauses;

namespace Spike.Patterns.Specification.Generic
{
    public abstract class Specification<TEntity, TSpecification>
        where TEntity : class 
        where TSpecification : Specification<TEntity, TSpecification>, new()
    {
        public enum Operator
        {
            And = 0,
            Or = 1
        }

        public class ClauseData
        {
            internal Operator Operator { get; }
            internal Clause<TEntity> Clause { get; }

            public ClauseData(Operator @operator, Clause<TEntity> specification)
            {
                Operator = @operator;
                Clause = specification;
            }
        }

        public List<ClauseData> Clauses { get;} = new List<ClauseData>();
        private Operator CurrentOperator { get; set; }

        protected TSpecification Clause(Clause<TEntity> clause)
        {
            Clauses.Add(new ClauseData(CurrentOperator, clause));

            CurrentOperator = Operator.And;
            return this as TSpecification;
        }

        protected TSpecification Clause(Expression<Func<TEntity, bool>> clauseData)
        {
            Clauses.Add(new ClauseData(CurrentOperator,
                    new DirectClause<TEntity>(clauseData)));

            CurrentOperator = Operator.And;
            return this as TSpecification;
        }

        /// <summary>
        /// This is not strictly needed as AND is the default.
        /// </summary>
        public TSpecification And()
        {
            CurrentOperator = Operator.And;
            return this as TSpecification;
        }

        public TSpecification Or()
        {
            CurrentOperator = Operator.Or;
            return this as TSpecification;
        }

        public virtual Clause<TEntity> Create(bool allowReturnAll = false)
        {
            return CreateInternal(allowReturnAll);
        }

        private Clause<TEntity> CreateInternal(bool allowReturnAll)
        {
            if (!Clauses.Any() && allowReturnAll != true)
            {
                throw new Exception("No clauses specified, to retrieve all you need to set that it is enabled");
            }

            Clause<TEntity> clause = null;

            foreach (var clauseData in Clauses)
            {
                if (clause == null)
                {
                    clause = clauseData.Clause;
                }
                else
                {
                    switch (clauseData.Operator)
                    {
                        case Operator.And:
                            clause &= clauseData.Clause;
                            break;
                        case Operator.Or:
                            clause |= clauseData.Clause;
                            break;
                        default:
                            throw new Exception("Unknown operator used");
                    }
                }
            }

            return clause;
        }
    }
}
