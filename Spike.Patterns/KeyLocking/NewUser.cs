using System;

namespace Spike.Patterns.KeyLocking
{
    public class NewUser
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Position { get; set; }

        public override string ToString()
        {
            return $"Position: [{Position}] User details [{Name}] [{Surname}]";
        }
    }
}
