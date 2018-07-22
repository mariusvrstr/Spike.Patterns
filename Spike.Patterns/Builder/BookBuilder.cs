using System;
using System.Collections.Generic;
using Spike.Patterns._Entities;

namespace Spike.Patterns.Builder
{
    public class BookBuilder : BookEntity
    {
        public BookBuilder(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }
        
        public BookBuilder FiveDysfunctions()
        {
            Title = "Five Dysfunctions of a Team";
            ReleaseDate = new DateTime(2002, 1, 1);

            Author = new AuthorBuilder().PatrickLencioni().Build();
            AuthorId = Author.Id;

            return this;
        }

        public BookBuilder TheGoal()
        {
            Title = "The Goal";
            ReleaseDate = new DateTime(1984, 1, 1);
            
            Author = new AuthorBuilder().EliyahuGoldratt().Build();
            AuthorId = Author.Id;
            
            return this;
        }

        public BookBuilder ThePhoenixProject()
        {

            Title = "The Phoenix Project";
            ReleaseDate = new DateTime(2013, 1, 1);
            
            Author = new AuthorBuilder().GeneKim().Build();
            AuthorId = Author.Id;

            return this;
        }

        public BookBuilder AlgorithmsToLiveBy()
        {

            Title = "Algorithms To Live By";
            ReleaseDate = new DateTime(2016, 1, 1);

            Author = new AuthorBuilder().BrianChristian().Build();
            AuthorId = Author.Id;

            return this;
        }

        public BookBuilder CrucialCOnversations()
        {
            Title = "Crucial Conversations";
            ReleaseDate = new DateTime(2002, 1, 1);

            Author = new AuthorBuilder().JosephGrenny().Build();
            AuthorId = Author.Id;

            return this;
        }

        public BookBuilder UpdateReleaseDate(DateTime newDate)
        {
            ReleaseDate = newDate;

            return this;
        }

        public BookEntity Build()
        {
            return new BookEntity
            {
                Id = Id,
                Title = Title,
                ReleaseDate = ReleaseDate,
                AuthorId = AuthorId,
                Author = Author
            };
        }

        public IEnumerable<BookEntity> BuildAll()
        {
            var books = new List<BookEntity>
            {
                FiveDysfunctions().Build(),
                TheGoal().Build(),
                ThePhoenixProject().Build(),
                AlgorithmsToLiveBy().Build(),
                CrucialCOnversations().Build()
            };
            
            return books;
        }
    }
}
