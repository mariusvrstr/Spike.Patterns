using System;
using System.Collections.Generic;
using System.Threading;
using Spike.Patterns.KeyLocking.Generic;

namespace Spike.Patterns.KeyLocking
{
    public class RegisterUser
    {
        public static List<Guid> TestContention { get; set; } = new List<Guid>();
 
        public static void SaveUser(NewUser newUser)
        {
            if (TestContention.Contains(newUser.Id))
            {
                throw new ThreadStateException("Concurrent Access to same ID detected");
            }

            TestContention.Add(newUser.Id);

            Console.WriteLine($"Saving... {newUser}");
            Thread.Sleep(1000);

            TestContention.Remove(newUser.Id);
        }


        public static NewUser SecurelyRegisterUser(NewUser newUser)
        {
            var outcome = KeyLockGuard<Guid, NewUser>.Protect(newUser.Id, (key) =>
            {
                SaveUser(newUser); // Will throw an exception if the same person gets saved at the same time
                return newUser;
            });

            return outcome;
        }

        public static NewUser UnsecurlyRegisterUser(NewUser newUser)
        {
            SaveUser(newUser);

            return newUser;
        }
    }
}
