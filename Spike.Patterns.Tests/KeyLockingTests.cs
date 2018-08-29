using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spike.Patterns.KeyLocking;

namespace Spike.Patterns.Tests
{
    [TestClass]
    public class KeyLockingTests
    {
        private IEnumerable<NewUser> CreateUserList(int size)
        {
            var johnId = Guid.NewGuid();
            var janeId = Guid.NewGuid();

            var users = new List<NewUser>();

            for (var i = 0; i < size; i++)
            {
                if (i == 10 || i == 11 || i == 12)
                {
                    users.Add(new NewUser
                    {
                        Id = janeId,
                        Name = "Jane",
                        Surname = "Doe",
                        Position = i
                    });
                }

                users.Add(new NewUser
                {
                    Id = johnId,
                    Name = "John",
                    Surname = "Doe",
                    Position = i
                });
            }

            return users;
        }

        [TestMethod]
        // [ExpectedException(typeof(ThreadStateException))]
        // these are expected but will happen in the background threads so cannot be catched here
        public void TestUnsecureUserRegister()
        {
            var size = 15;
            var users = CreateUserList(size);

            foreach (var user in users)
            {
                var thread = new Thread((callbackUrl) => RegisterUser.UnsecurlyRegisterUser(user));
                thread.Start();
            }

            Thread.Sleep(size * 1000);
            // Look at output
        }

        [TestMethod]
        public void TestSafeKeyLockedUserRegister()
        {
            var size = 15;
            var users = CreateUserList(size);

            foreach (var user in users)
            {
                var thread = new Thread((callbackUrl) => RegisterUser.SecurelyRegisterUser(user));
                thread.Start();
            }

            Thread.Sleep(size*1000);
            // Look at output
        }
    }
}
