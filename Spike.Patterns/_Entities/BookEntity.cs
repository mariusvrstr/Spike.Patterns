using System;
using System.Collections.Generic;

namespace Spike.Patterns._Entities
{
    public class BookEntity : EntityBase
    {
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Guid AuthorId { get; set; }

        public AuthorEntity Author { get; set; }

        public override bool Equals(object obj)
        {
            var entity = obj as BookEntity;
            return entity != null &&
                   base.Equals(obj) &&
                   Title == entity.Title &&
                   ReleaseDate == entity.ReleaseDate &&
                   AuthorId.Equals(entity.AuthorId) &&
                   EqualityComparer<AuthorEntity>.Default.Equals(Author, entity.Author);
        }

        public override int GetHashCode()
        {
            var hashCode = 536060548;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + ReleaseDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(AuthorId);
            hashCode = hashCode * -1521134295 + EqualityComparer<AuthorEntity>.Default.GetHashCode(Author);
            return hashCode;
        }
    }
}
