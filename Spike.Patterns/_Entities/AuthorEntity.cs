
using System.Collections.Generic;

namespace Spike.Patterns._Entities
{
    public class AuthorEntity : EntityBase
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public override bool Equals(object obj)
        {
            var entity = obj as AuthorEntity;
            return entity != null &&
                   base.Equals(obj) &&
                   Name == entity.Name &&
                   Surname == entity.Surname;
        }

        public override int GetHashCode()
        {
            var hashCode = 305228700;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            return hashCode;
        }
    }
}
