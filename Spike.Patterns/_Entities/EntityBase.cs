using System;
using System.Collections.Generic;

namespace Spike.Patterns._Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            var @base = obj as EntityBase;
            return @base != null &&
                   Id.Equals(@base.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<Guid>.Default.GetHashCode(Id);
        }
    }
}
