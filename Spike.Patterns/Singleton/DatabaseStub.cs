using System.Collections.Generic;
using System.Linq;
using Spike.Patterns.Builder;
using Spike.Patterns.Singleton.Generic;
using Spike.Patterns._Entities;

namespace Spike.Patterns.Singleton
{
    public class DatabaseStub : SingletonBase<DatabaseStub>, ISingleton
    {
        public List<BookEntity> Books { get; set; }

        public List<AuthorEntity> Authors { get; set; }
        
        public override void Initialize()
        {
            Books = new BookBuilder().BuildAll().ToList();
            Authors = new List<AuthorEntity>();

            foreach (var book in Books)
            {
                Authors.Add(book.Author);
            }
        }
    }
}
