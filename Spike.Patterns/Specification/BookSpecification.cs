using System;
using Spike.Patterns.Specification.Generic;
using Spike.Patterns._Entities;

namespace Spike.Patterns.Specification
{
    public class BookSpecification : Specification<BookEntity, BookSpecification>
    {
        public BookSpecification BooksSince(DateTime date)
        {
            return 
                    Clause(book => book.ReleaseDate > date)
                   .Clause(book => book.ReleaseDate > DateTime.Now.AddYears(-500));
        }

        public BookSpecification BooksBefore(DateTime date)
        {
            return
                Clause(book => book.ReleaseDate < date)
                    .Clause(book => book.ReleaseDate > DateTime.Now.AddYears(-500));
        }

        public BookSpecification TitleStartingWith(string title)
        {
            return Clause(book => book.Title.StartsWith(title));
        }
    }
}
