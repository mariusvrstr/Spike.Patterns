using System;
using System.Collections.Generic;
using Spike.Patterns._Entities;

namespace Spike.Patterns.Builder
{
    public class AuthorBuilder : AuthorEntity
    {
        public AuthorBuilder(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }

        public AuthorBuilder JosephGrenny()
        {
            Name = "Joseph";
            Surname = "Grenny";

            return this;
        }

        public AuthorBuilder BrianChristian()
        {
            Name = "Brian";
            Surname = "Christian";

            return this;
        }

        public AuthorBuilder GeneKim()
        {
            Name = "Gene";
            Surname = "Kim";

            return this;
        }

        public AuthorBuilder EliyahuGoldratt()
        {
            Name = "Eliyahu";
            Surname = "Goldratt";

            return this;
        }

        public AuthorBuilder PatrickLencioni()
        {
            Name = "Patrick";
            Surname = "Lencioni";

            return this;
        }

        public IEnumerable<AuthorEntity> BuildAll()
        {
            var authors = new List<AuthorEntity>
            {
                JosephGrenny().Build(),
                BrianChristian().Build(),
                GeneKim().Build(),
                EliyahuGoldratt().Build(),
                PatrickLencioni().Build()
            };

            return authors;
        }

        public AuthorEntity Build()
        {
            return new AuthorEntity
            {
                Id = Id,
                Name = Name,
                Surname = Surname
            };
        }
    }
}
