using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spike.Patterns.Singleton;
using Spike.Patterns.Specification;

namespace Spike.Patterns.Tests
{
    [TestClass]
    public class SpecificationTests
    {
        [TestMethod]
        public void TestBasicAndSpecification()
        {
            var bookList = DatabaseStub.Instance.Books;
            var bookName = "The Phoenix Project";

            var specification = new BookSpecification();

            specification
                .BooksSince(DateTime.Now.AddYears(-10))
                .TitleStartingWith(bookName); 
   
            var expression = specification.Create();

            var result = bookList.FindAll(x => expression.SatisfiedBy(x));

           Assert.IsTrue(result.Count == 1);
           Assert.IsTrue(result.FirstOrDefault()?.Title.StartsWith(bookName) ?? false);
        }

        [TestMethod]
        public void TestBasicOrSpecification()
        {
            var bookList = DatabaseStub.Instance.Books;
            var bookName = "The Goal";

            var specification = new BookSpecification();

            specification
                .BooksSince(DateTime.Now.AddYears(-10))
                    .Or()
                .TitleStartingWith(bookName);

            var expression = specification.Create();

            var result = bookList.FindAll(x => expression.SatisfiedBy(x));

            Assert.IsTrue(result.Count > 1);
            Assert.IsTrue(result.Exists(x => x.Title.StartsWith(bookName)));
        }

        [TestMethod]
        public void TestGroupSpecification()
        {
            var bookList = DatabaseStub.Instance.Books;
            var bookName = "The";

            var specification = new BookSpecification();

            specification
                .BooksSince(DateTime.Now.AddYears(-10))
                    .Or()
                .Group()
                    .TitleStartingWith(bookName)
                        .And() 
                    .BooksBefore(DateTime.Now.AddYears(-10))
                .EndGroup();

            var expression = specification.Create();

            var result = bookList.FindAll(x => expression.SatisfiedBy(x));

            Assert.IsTrue(result.Count > 1);
            Assert.IsTrue(result.Exists(x => x.Title.StartsWith(bookName)));
        }
    }
}
